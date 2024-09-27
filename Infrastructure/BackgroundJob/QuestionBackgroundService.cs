using Application.Abstractions.Repositories;
using Application.Abstractions.Service;
using Domain.Entity;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.BackgroundJob
{
    public class QuestionBackgroundService : BackgroundService
    {
        private readonly IFreeQuestionRepository _questionRepository;
        private readonly IGetApiQuestionService _questionApi;
        private readonly ILogger<QuestionBackgroundService> _logger;

        public QuestionBackgroundService(
            IFreeQuestionRepository questionRepository,
            IGetApiQuestionService questionApi,
            ILogger<QuestionBackgroundService> logger)
        {
            _questionRepository = questionRepository;
            _questionApi = questionApi;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // Run this task every month (you can adjust the interval as needed)
                    await ProcessQuestionsAsync();

                    _logger.LogInformation("Question update process completed successfully.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while processing questions.");
                }

                
                await Task.Delay(TimeSpan.FromDays(30), stoppingToken);
            }
        }

        private async Task ProcessQuestionsAsync()
        {
            _logger.LogInformation("Starting to process questions.");

            // Subjects for which we need to fetch and delete questions
            string[] subjects = { "chemistry", "physics", "mathematics", "english" };

            // Delete 40 old questions for each subject
            foreach (var subject in subjects)
            {
                _logger.LogInformation($"Deleting old questions for subject: {subject}");
                await _questionRepository.DeleteOldQuestionsAsync(subject, 40);
            }

            // Fetch 40 new questions for each subject using Refit
            var externalQuestions = await _questionApi.GetQuestionsAsync();

            if (externalQuestions == null || !externalQuestions.Any())
            {
                _logger.LogWarning("No questions found in the external API.");
                return;
            }


            foreach (var externalQuestion in externalQuestions)
            {
                var question = FreeQuestion.Create(
                    externalQuestion.QuestionContent,
                    externalQuestion.SubjectName,
                    externalQuestion.ExamType,
                    externalQuestion.ExamYear,
                    externalQuestion.ImageUrl
                );

                
                foreach (var option in externalQuestion.Options)
                {
                    question.AddOption(option.Content, option.OptionAlpha, option.IsCorrect, option.ImageUrl);
                }

                await _questionRepository.AddAsync(question);
            }

            _logger.LogInformation("Successfully added new questions to the database.");
        }
    }
}
