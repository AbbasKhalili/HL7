using System;
using System.Collections.Generic;
using System.Linq;
using Host.Cobas.Blocks;
using Host.Cobas.Lines;
using Host.Framework.Chain;
using Newtonsoft.Json;

namespace Host.Cobas
{
    //public static class CobasIntegra400ChainBuilder
    //{
    //    public static IHandler<string, List<string>> CreateInstance(IVisitor visitor)
    //    {
    //        var t1 = new Block02CalibrationResult();
    //        t1.Visit(visitor);

    //        var t2 = new Block03ControlResult();
    //        t2.Visit(visitor);

    //        var t3 = new Block04PatientResults();
    //        t3.Visit(visitor);

    //        return new ChainBuilder<string, List<string>>()
    //            .WithHandler(t1)
    //            .WithHandler(t2)
    //            .WithHandler(t3)
    //            .Build();
    //    }
    //}
    public class CobasIntegra400 : CobasBase
    {
        private readonly string _deviceName;

        public CobasIntegra400(string deviceName)
        {
            _deviceName = deviceName;
        }

        public string Response(string response)
        {
            var data = response.Split($"{LF}");
            var header = data[1].Split(" ");
            var blockCode = header.Last();

            var t1 = data.ToList().IndexOf(char.ToString('\u0002'));
            var t2 = data.ToList().IndexOf(char.ToString('\u0003'));

            var body = data.Skip(t1 + 1).Take(t2 - t1 - 1).ToList();

            //var chan = CobasIntegra400ChainBuilder.CreateInstance(visitor);
            //chan.Handle(blockCode, body, ress);

            object t;
            t = null;

            switch (blockCode)
            {
                case "00":
                {
                    t = new Block00Idle(_deviceName, body);
                    break;
                }
                case "02":
                {
                    t = new Block02CalibrationResult(body);
                    break;
                }
                case "03":
                {
                    t = new Block03ControlResult(body);
                    break;
                }
                case "04":
                {
                    t = new Block04PatientResults(body);
                    break;
                }
                case "05":
                {
                    t = new Block05CalibrationResultLotInfo(body);
                    break;
                }
                case "06":
                {
                    t = new Block06ControlResultLotInfo(body);
                    break;
                }
                case "07":
                {
                    t = new Block07PatientResultLotInfo(body);
                    break;
                }
                case "08":
                {
                    t = new Block08ResultRequestResponse(body);
                    break;
                }
                case "19":
                {
                    t = new Block19OrderManipulationResponse(body);
                    break;
                }
                case "49":
                {
                    t = new Block49PatientManipulationResponse(body);
                    break;
                }
                case "61":
                {
                    t = new Block61SlotConfiguration(body);
                    break;
                }
                case "62":
                {
                    t = new Block62SampleTubeInformation(body);
                    break;
                }
                case "63":
                {
                    t = new {blockCode= 63, desc="nadarim"};
                    break;
                }
                case "69":
                {
                    t = new Block69ServiceRequestResponse(body);
                    break;
                }
                case "91":
                {
                    t = new Block91SystemStatusResponse(body);
                    break;
                }
                case "93":
                {
                    t = new Block93ProtocolVersionData(body);
                    break;
                }
                case "99":
                {
                    t = new Block99ControlMessage(body);
                    break;
                }
            }
            return  JsonConvert.SerializeObject(t);
        }

        public string Idle()
        {
            var t = new Block00Idle(_deviceName);
            return t.Generate();
        }

        public string ResultRequest(string request)
        {
            var t = new Block09ResultRequest(_deviceName);
            return request switch
            {
                "09-01" => t.Code1001(),
                "09-02" => t.Code1002(),
                "09-03" => t.Code1003(),
                "09-04" => t.Code1004(),
                "09-05" => t.Code1005(),
                "09-06" => t.Code1006(),
                "09-07" => t.Code1007(),
                "09-08" => t.Code1008(),
                "09-09" => t.Code1009(),
                "09-11" => t.Code1011(),
                "09-17" => t.Code1017(),
                "09-18" => t.Code1018(),
                "09-19" => t.Code1019(),
                _ => ""
            };
        }

        public string DefinePatient(string patientId, DateTime birthday, string sex, string leaderText1, string leaderText2="", string leaderText3="")
        {
            var patid = Line50PatientId.Create(patientId);
            var patinfo = Line51PatientInfo.Create(birthday, sex, leaderText1, leaderText2, leaderText3);

            var r = new Block40PatientEntry(_deviceName);
            r.Create(patid, patinfo);

            return r.Generate();
        }

        public string DeleteOrder(string orderNumber, DateTime? orderDate,string sampleType="")
        {
            var r = new Block11OrderDeletion(_deviceName);
            return r.DeleteSampleOrder(Line53OrderId.Create(orderNumber, orderDate, sampleType));
        }
        public string DeleteTest(List<int> testIds, string orderNumber)
        {
            var r = new Block11OrderDeletion(_deviceName);
            return r.DeleteTestOrder(GetTestsList(testIds), Line53OrderId.Create(orderNumber, null));
        }

        private List<Line55TestId> GetTestsList(List<int> testIds)
        {
            return testIds.Select(Line55TestId.Create).ToList();
        }

        public string NewSampleOrder(string patientId, string orderNumber, DateTime? orderDate, 
            int rackNumber, int tubeNumber, OrderPriority priority,string sampleName, List<int> testIds, string leaderTest1="", string leaderTest2="",
            string sampleType = "")
        {
            var r = new Block10OrderEntry(_deviceName);

            r.Create(Line50PatientId.Create(patientId), Line53OrderId.Create(orderNumber, orderDate, sampleType),
                Line54OrderInformation.Create(rackNumber, tubeNumber, priority, leaderTest1, leaderTest2),
                Line56SampleName.Create(sampleName), GetTestsList(testIds));

            return r.Generate();
        }

        public string AddTestToSampleOrder(string patientId, string orderNumber, List<int> testIds)
        {
            var r = new Block10OrderEntry(_deviceName);
            return r.AddTestToExistingOrder(Line50PatientId.Create(patientId), Line53OrderId.Create(orderNumber,null), GetTestsList(testIds));
        }

        public string CalibrationControlOrder(SpecialOrderType orderType, string attribute, List<int> testIds)
        {
            var r = new Block10OrderEntry(_deviceName);
            return r.CalibrationControlOrder(Line52SpecialOrderSelection.Create(orderType,attribute), GetTestsList(testIds));
        }

        public string DeleteSampleOrder(string orderNumber)
        {
            var r = new Block11OrderDeletion(_deviceName);
            return r.DeleteSampleOrder(Line53OrderId.Create(orderNumber,null));
        }

        public string DeleteTestOrder(string orderNumber, List<int> testIds)
        {
            var r = new Block11OrderDeletion(_deviceName);
            return r.DeleteTestOrder(GetTestsList(testIds), Line53OrderId.Create(orderNumber, null));
        }

        public string PatientEntry(string patientId, DateTime? birthday, string sex,string leaderText1, string leaderText2="", string leaderText3="")
        {
            var r = new Block40PatientEntry(_deviceName);
            r.Create(Line50PatientId.Create(patientId), Line51PatientInfo.Create(birthday, sex, leaderText1, leaderText2, leaderText3));
            return r.Generate();
        }

        public string PatientDeletion(string patientId)
        {
            var r = new Block41PatientDeletion(_deviceName);
            r.Create(Line50PatientId.Create(patientId));
            return r.Generate();
        }

        public string PatientModification(string patientId, DateTime? birthday, string sex, string leaderText1, string leaderText2 = "", string leaderText3 = "")
        {
            var r = new Block42PatientModification(_deviceName);
            r.Create(Line50PatientId.Create(patientId), Line51PatientInfo.Create(birthday, sex, leaderText1, leaderText2, leaderText3));
            return r.Generate();
        }

        public string MultiConfigurationService(ServiceRequestTypes requestType)
        {
            var r = new Block60MultiConfigurationService(_deviceName);
            r.Create(Line40ServiceSelection.Create(requestType));
            return r.Generate();
        }

        public string SystemStatusRequest()
        {
            var r = new Block90SystemStatusRequest(_deviceName);
            return r.Generate();
        }

        public string ProtocolVersionRequest()
        {
            var r = new Block92ProtocolVersionRequest(_deviceName);
            return r.Generate();
        }
    }
}