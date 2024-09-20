using System.ComponentModel.DataAnnotations;

namespace BlazorAntdProApp.Models.QuotationBuilder.LaneBuilderForm
{
    public class Lane
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Carrier { get; set; }
        public string OriginPort { get; set; }

        public string DestinationPort { get; set; }

        public string Routing { get; set; }

        public string DestinationDoor { get; set; }

        public int DoorRate { get; set; }

    }
}
