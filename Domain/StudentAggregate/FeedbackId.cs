﻿using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.StudentAggregate
{
    public class FeedbackId : ValueObject<FeedbackId>
    {
        public Guid Value { get; init; }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static FeedbackId CreateUniqueId() => Create(Guid.NewGuid());

        public static FeedbackId Create(Guid value) => new FeedbackId { Value = value };
    }
}
