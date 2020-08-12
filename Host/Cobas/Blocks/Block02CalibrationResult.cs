using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using Host.Cobas.Lines;

namespace Host.Cobas.Blocks
{
    public interface ILineCode {}
    public interface IVisitorElement
    {
        void Visit(IVisitor visitor);
    }
    public class Block02CalibrationResult  : CobasIntegra400Base
    {
        private const string BlockCode = "02";

        public Line55TestId TestId { get; private set; }
        public Line01ResultTime ResultTime { get; private set; }
        public Line03StandardRates StandardRates { get; private set; }
        public Line04CalibrateCurve CalibrateCurve { get; private set; }
        public Line00ResultData ResultData { get; private set; }
        public Line07ABSSampleCheck ABSSampleCheck { get; set; }


        public Block02CalibrationResult(List<string> body)
        {
            var line55 = body.FirstOrDefault(a => a.StartsWith("55"));
            var line01 = body.FirstOrDefault(a => a.StartsWith("01"));
            var line03 = body.FirstOrDefault(a => a.StartsWith("03"));
            var line04 = body.FirstOrDefault(a => a.StartsWith("04"));
            var line00 = body.FirstOrDefault(a => a.StartsWith("00"));
            var line07 = body.FirstOrDefault(a => a.StartsWith("07"));

            TestId = new Line55TestId().Detect(line55);
            ResultTime = new Line01ResultTime().Detect(line01);
            StandardRates = new Line03StandardRates().Detect(line03);
            CalibrateCurve = new Line04CalibrateCurve().Detect(line04);
            ResultData = new Line00ResultData().Detect(line00);
            ABSSampleCheck = new Line07ABSSampleCheck().Detect(line07);
        }

        //protected override bool CanHandleRequest(string header)
        //{
        //    return header == BlockCode;
        //}


        //protected override void HandleRequest(List<string> body, List<ILineCode> response)
        //{
            

        //    _visitor.Accept(this);
        //}
    }

    public interface IVisitor
    {
        void Accept(Block02CalibrationResult instance);
        void Accept(Block03ControlResult instance);
        void Accept(Block04PatientResults instance);
    }

    public class ConcreteVisitor1 : IVisitor
    {
        public void Accept(Block02CalibrationResult instance)
        {
            
        }

        public void Accept(Block03ControlResult instance)
        {
            
        }

        public void Accept(Block04PatientResults instance)
        {
            
        }
    }

}