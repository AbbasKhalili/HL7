using System;
using System.Collections.Generic;
using Host.Tools;

namespace Host.Cobas.Lines
{
    public class Line51PatientInfo : BaseLineCode<Line51PatientInfo>
    {
        public DateTime? Birthday { get; private set; }
        public string Sex { get; private set; }
        public string LeaderText1 { get; private set; }
        public string LeaderText2 { get; private set; }
        public string LeaderText3 { get; private set; }


        public Line51PatientInfo() : base("51") { }


        public static Line51PatientInfo Create(DateTime? birthday, string sex, string leaderText1, string leaderText2="", string leaderText3="")
        {
            return new Line51PatientInfo()
            {
                Birthday = birthday,
                Sex = sex,
                LeaderText1 = leaderText1.ToFixLength(31),
                LeaderText2 = leaderText2,
                LeaderText3 = leaderText3
            };
        }

        public string Build()
        {
            var text2 = !string.IsNullOrEmpty(LeaderText2) ? $"_{LeaderText2.ToFixLength(21)}" : "";
            var text3 = !string.IsNullOrEmpty(LeaderText3) ? $"_{LeaderText3.ToFixLength(21)}" : "";
            return $"{LineCode}_{Birthday.ToFixLength()}_{Sex.ToFixLength(1)}_{LeaderText1.ToFixLength(31)}{text2}{text3}{LF}";
        }


        protected override Line51PatientInfo Assign(List<string> data)
        {
            Birthday = data[1].ToDate();
            Sex = data[2];
            LeaderText1 = data[3];
            LeaderText2 = data.Count >= 5 ? data[4] : "";
            LeaderText3 = data.Count >= 6 ? data[5] : "";
            return this;
        }
    }
}