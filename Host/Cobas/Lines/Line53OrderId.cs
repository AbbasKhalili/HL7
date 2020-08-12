using System;
using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line53OrderId : BaseLineCode<Line53OrderId> 
    {
        public string OrderNumber { get; private set; }
        public DateTime? OrderDate { get; private set; }
        public string SampleType { get; private set; }

        public Line53OrderId() : base("53"){ }

        public static Line53OrderId Create(string orderNumber, DateTime? orderDate, string sampleType = "")
        {
            return new Line53OrderId()
            {
                OrderNumber = orderNumber,
                OrderDate = orderDate,
                SampleType = sampleType
            };
        }

        public string Build()
        {
            var sampleType = !string.IsNullOrEmpty(SampleType) ? $"_{SampleType.ToFixLength(3)}" : "";
            return $"{LineCode}_{OrderNumber.ToFixLength(15)}_{OrderDate.ToFixLength()}{sampleType}{LF}";
        }
        
        protected override Line53OrderId Assign(List<string> data)
        {
            OrderNumber = data[1];
            OrderDate = data[2].ToDate();
            SampleType = data[3];
            return this;
        }
    }
}