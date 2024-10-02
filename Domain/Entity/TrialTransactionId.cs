﻿using CBTPreparation.BuildingBlocks.Domain;

namespace Domain.Entity
{
    public class TrialTransactionId : ValueObject<TrialTransactionId>
    {
        public Guid Value { get; init; }
        private TrialTransactionId(Guid id)
        {
            Value = id;
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static TrialTransactionId CreateUniqueId() => Create(Guid.NewGuid());

        public static TrialTransactionId Create(Guid value) => new(value);
    }
}
