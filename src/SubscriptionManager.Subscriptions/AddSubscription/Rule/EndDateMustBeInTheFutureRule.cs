using System;
using System.Threading.Tasks;
using R2.Aspect.Validation;
using SubscriptionManager.Subscriptions.AddSubscription.Exception;

namespace SubscriptionManager.Subscriptions.AddSubscription.Rule
{
    public class EndDateMustBeInTheFutureRule : IValidationRule<AddSubscriptionCommand>
    {
        public Task TestAsync(AddSubscriptionCommand command)
        {
            var endDate = command.StartDate.Value.AddMonths(command.DurationInMonths.Value);

            if (endDate <= DateTime.Now)
            {
                throw new EndDateMustBeInTheFutureException();
            }

            return Task.FromResult(0);
        }
    }
}