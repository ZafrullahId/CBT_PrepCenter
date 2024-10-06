namespace CBTPreparation.Infrastructure.Persistence.Context
{
    public static class CBTDbContextSchema
    {
        public const string DefaultSchema = "cbtprep";
        public const string DefaultConnectionStringName = "cbtDbConnection";
        public static class AdminDbSchema
        {
            public const string TableName = "Admins";
        }
        public static class CbtSessionDbSchema
        {
            public const string TableName = "CbtSessions";
            public const string StudentId = "StudentId";
            public const string SessionQuestionTableName = "SessionQuestions";
            public const string PaidOptionTableName = "PaidOptions";
            public const string PaidOptionBackendField = "_paidOptions";
            public const string SessionQuestionBackendField = "_sessionQuestions";
        }
        public static class FreeQuestionDbSchema
        {
            public const string TableName = "FreeQuestions";
            public const string FreeOptionTableName = "FreeOption";
            public const string FreeOptionBackendField = "_freeOptions";
        }
        public static class StudentDbSchema
        {
            public const string TableName = "Students";
            public const string ForeignKey = "StudentId";
            public const string CourseName = "Course_Name";
            public const string FeedBackTableName = "Feedbacks";
            public const string TrialTransactionTableName = "TrialTransactions";
            public const string TrialTransactionForeignKey = "StudentId";
            public const string TrialTransactionTotalAmountBackendField = "_totalAmount";
            public const string DepartmentName = "Department_Name";
            public const string CourseBackendField = "_courses";
            public const string FeedbacksBackendField = "_feedbacks";
        }
        public static class UserDbSchema
        {
            public const string TableName = "Users";
            public const string ForeignKey = "UserId";
            public const string RoleName = "Role_Name";
        }
    }
}
