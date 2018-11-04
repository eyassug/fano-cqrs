namespace Fano.CQRS.EventSourcing.Tests
{
    using System.Linq;
    using System.Collections.Generic;
    using Xunit;


    class Order : EventSourced
    {
        protected Order(Guid id) : base(id)
        {
            base.Handles<OrderCreated>(this.On);
        }

        public Order(Guid id, IEnumerable<IVersionedEvent> history) : this(id)
        {
            this.LoadFrom(history);
        }

        public Order(string username) : this(Guid.NewGuid())
        {
            Update(new OrderCreated
            {
                Username = username,
                CreatedDate = DateTime.Now
            });
        }
        public DateTime? CreatedDate { get; set; }
        public string Username { get; set; }
        void On(OrderCreated @event)
        {
            this.CreatedDate = @event.CreatedDate;
            this.Username = @event.Username;
        }
    }

    class OrderCreated : VersionedEvent
    {
        public string Username { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class EventSourcedTests
    {
        [Fact]
        public void Ctor_LoadFromHistory_SetsIdAndProperties()
        {
            var orderId = Guid.Parse("704D2D8E-C79B-4304-9FD2-26B3CD723F1C");
            DateTime today = DateTime.Today;
            var username = "admin";
            var pastEvent = new OrderCreated { Username = username, CreatedDate = today };

            var order = new Order(orderId, new[] { pastEvent });

            Assert.Equal(orderId, order.Id);
            Assert.Equal(today, order.CreatedDate);
            Assert.Equal(username, order.Username);
        }

        [Fact]
        public void Ctor_New_SetsIdAndEvents()
        {
            var username = "admin";

            var order = new Order(username);

            Assert.Equal(1, order.Events.Count());
            var newEvent = order.Events.SingleOrDefault();
            Assert.Equal(typeof(OrderCreated), newEvent.GetType());
            Assert.Equal(0, order.Version);
            Assert.Equal(order.Id, newEvent.SourceId);
        }
    }
}
