namespace BlazorAntdProApp.Models.GroupTable
{
    public class LaneRowItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Carrier { get; set; }
        public string OriginPort { get; set; }

        public string DestinationPort { get; set; }

        public string Routing { get; set; }

        public string DestinationDoor { get; set; }

        public int DoorRate { get; set; }

        public string Door { get; set; }

        public int Transit { get; set; }
        public string Commodity { get; set; }
        public string ContainerSize { get; set; }
        public int NewOceanFreight { get; set; }
        public int CurrentOceanFreight { set; get; }
        public int NewBafLss { get; set; }
        public int CurrentBafLss { set; get; }
        public int NewDps { get; set; }
        public int CurrentDps { set; get; }

        public int NewTotal { get; set; }
        public int CurrentTotal { get; set; }

        public List<ExtraData> ExtraDataList { get; set; }
    }

   public class ExtraData
    {
        public int TMF { get; set; }
        public int ISP { get; set; }
        public int AMS { get; set; }
        public int ADD { get; set; }
        public int ARR { get; set; }
        public int PSS { get; set; }
        public int CRF { get; set; }
    }
}
