using BlazorAntdProApp.Models.GroupTable;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Xml.Linq;



namespace BlazorAntdProApp.Pages.GroupTable
{
    public partial class Index
    {
        [Inject]
        IJSRuntime JS { get; set; }

        [Inject]
        IMessageService _messageService { get; set; }

        private DotNetObjectReference<Index>? dotNetHelper;

        private IJSObjectReference? module;


        Boolean _loading = false;
        int _total=1000;
        int _pageIndex = 0;
        int _pageSize = 20;




        public LaneRecord[] data =
         {
            new()
            {
                Carrier = "DarkStar1-1",
                OriginPort = "NewYork",
                DestinationPort = "Shanghai",
                Routing = "Plan A",
                DestinationDoor = "Black Gate",
                DoorRate = 1000,
                Door = "BG",
                Transit = 20,
                Commodity = "CDSM/FAK/GARM",
                ContainerSize = "40'",
                NewOceanFreight = 5000,
                CurrentOceanFreight = 6000,
                NewBafLss = 3000,
                CurrentBafLss = 2000,
                NewDps = 3000,
                CurrentDps = 2000,
                ISP = 1000,
                AMS = 2000,
                ARR = 4000,
                NewTotal = 9999,
                CurrentTotal = 9999
            },
         new()
         {
             Carrier = "DarkStar1-1",
             OriginPort = "NewYork",
             DestinationPort = "Shanghai",
             Routing = "Plan A",
             DestinationDoor = "Black Gate",
             DoorRate = 1000,
             Door = "BG",
             Transit = 20,
             Commodity = "CDSM/FAK/GARM",
             ContainerSize = "40'",
             NewOceanFreight = 5000,
             CurrentOceanFreight = 6000,
             NewBafLss = 3000,
             CurrentBafLss = 2000,
             NewDps = 3000,
             CurrentDps = 2000,
             ISP = 8999,
             AMS = 9999,
             ARR = 9999,
             NewTotal = 9999,
             CurrentTotal = 9999
         },
         new()
         {
             Carrier = "DarkStar1-2",
             OriginPort = "NewYork",
             DestinationPort = "Shanghai",
             Routing = "Plan A",
             DestinationDoor = "Black Gate",
             DoorRate = 1000,
             Door = "BG",
             Transit = 20,
             Commodity = "CDSM/FAK/GARM",
             ContainerSize = "40'",
             NewOceanFreight = 5000,
             CurrentOceanFreight = 6000,
             NewBafLss = 3000,
             CurrentBafLss = 2000,
             NewDps = 3000,
             CurrentDps = 2000,
             NewTotal = 9999,
             CurrentTotal = 9999
         },
    };

        LaneRowItem[]
        _formatedTableData = [];



        protected override void OnInitialized()
        {


            LaneRowItem[] formatedTableData = [];

            foreach (LaneRecord originData in data)
            {
                if (formatedTableData.Length == 0)
                {
                    LaneRowItem resItem = dataTransform(originData);
                    formatedTableData = formatedTableData.Append(resItem);
                }
                else
                {
                    for (int i = 0; i < formatedTableData.Length; i++)
                    {
                        if (formatedTableData[i].Carrier == originData.Carrier &&
                        formatedTableData[i].OriginPort == originData.OriginPort &&
                        formatedTableData[i].DestinationPort == originData.DestinationPort &&
                        formatedTableData[i].Routing == originData.Routing &&
                        formatedTableData[i].DestinationDoor == originData.DestinationDoor &&
                        formatedTableData[i].DoorRate == originData.DoorRate &&
                        formatedTableData[i].Door == originData.Door &&
                        formatedTableData[i].Transit == originData.Transit &&
                        formatedTableData[i].Commodity == originData.Commodity &&
                        formatedTableData[i].ContainerSize == originData.ContainerSize &&
                        formatedTableData[i].NewOceanFreight == originData.NewOceanFreight &&
                        formatedTableData[i].CurrentOceanFreight == originData.CurrentOceanFreight &&
                        formatedTableData[i].NewBafLss == originData.NewBafLss &&
                        formatedTableData[i].CurrentBafLss == originData.CurrentBafLss &&
                        formatedTableData[i].NewDps == originData.NewDps &&
                        formatedTableData[i].CurrentDps == originData.CurrentDps &&
                        formatedTableData[i].NewTotal == originData.NewTotal &&
                        formatedTableData[i].CurrentTotal == originData.CurrentTotal
                        )
                        {
                            LaneRowItem rowItem = dataTransform(originData);
                            List<ExtraData> newList = formatedTableData[i].ExtraDataList.Union(rowItem.ExtraDataList).ToList();
                            formatedTableData[i].ExtraDataList = newList;
                            break;
                        }
                        else
                        {
                            LaneRowItem rowItem = dataTransform(originData);
                            formatedTableData = formatedTableData.Append(rowItem);
                            break;
                        }
                    }
                }

            }
            _formatedTableData = formatedTableData;

        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                dotNetHelper = DotNetObjectReference.Create(this);
                await JS.InvokeVoidAsync("GroupTableHelper.setDotNetHelper",
                    dotNetHelper);
            }
        }

        [JSInvokable]
        public void loadMoreForJs()
        {
            handleLoadMore();
        }


        private LaneRowItem dataTransform(LaneRecord record)
        {

            ExtraData extraData = new ExtraData()
            {
                TMF = record.TMF,
                ISP = record.ISP,
                AMS = record.AMS,
                ADD = record.ADD,
                ARR = record.ARR,
                PSS = record.PSS,
                CRF = record.CRF
            };

            return new LaneRowItem()
            {
                Carrier = record.Carrier,
                OriginPort = record.OriginPort,
                DestinationPort = record.DestinationPort,
                Routing = record.Routing,
                DestinationDoor = record.DestinationDoor,
                DoorRate = record.DoorRate,
                Door = record.Door,
                Transit = record.Transit,
                Commodity = record.Commodity,
                ContainerSize = record.ContainerSize,
                NewOceanFreight = record.NewOceanFreight,
                CurrentOceanFreight = record.CurrentOceanFreight,
                NewBafLss = record.NewBafLss,
                CurrentBafLss = record.CurrentBafLss,
                NewDps = record.NewDps,
                CurrentDps = record.CurrentDps,
                NewTotal = record.NewTotal,
                CurrentTotal = record.CurrentTotal,
                ExtraDataList = [extraData]
            };
        }


        private void handleLoadMore()
        {
            Console.WriteLine(_formatedTableData.Length);
            LaneRowItem[] newData=[];
            _pageIndex = _pageIndex + 1;

            for (int i = 0; i < 30; i++)
            {
                Random r = new Random();
                LaneRecord record = new LaneRecord()
                {
                    Carrier = "DarkStar1-1",
                    OriginPort = "NewYork",
                    DestinationPort = "Shanghai",
                    Routing = "Plan A",
                    DestinationDoor = "Black Gate",
                    DoorRate = 1000,
                    Door = "BG",
                    Transit = 20,
                    Commodity = "CDSM/FAK/GARM",
                    ContainerSize = "40'",
                    NewOceanFreight = 5000,
                    CurrentOceanFreight = 6000,
                    NewBafLss = 3000,
                    CurrentBafLss = 2000,
                    NewDps = 3000,
                    CurrentDps = 2000,
                    NewTotal = 9999,
                    CurrentTotal = 9999
                };

                LaneRowItem newRecord = dataTransform(record);
               newData= newData.Append(newRecord);
            }

            _formatedTableData = _formatedTableData.Union(newData).ToArray();
            StateHasChanged();
        }
    }
}

