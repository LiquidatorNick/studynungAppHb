using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studynung.ProtectiveEarthing.Logic.Managers
{
    public class Log
    {
        private static Log _log;

        public static Log GetInstance()
        {
            return _log ?? (_log = new Log());
        }

        public Log()
        {
            _messages = new List<string>();
        }

        public List<string> _messages;

        public bool IsContinue { get; set; }
        public string AllowableResistance { get; set; }

        public string FirstKcResult { get; set; }
        public string SecondKcResult { get; set; }

        public string FirstCalcValueResistivitySoil { get; set; } //результат розрахункове значення питомого опору ґрунту. Ro_r
        public string SecondCalcValueResistivitySoil { get; set; } //результат розрахункове значення питомого опору ґрунту. Ro_r 

        public string ResistivitySoil { get; set; }
        public string FirstRResult { get; set; }
        public string SecondRResult { get; set; }

        public string ComparisonResistance { get; set; }

        public string CountElectrodes { get; set; }
        public string FirstNude { get; set; }
        public string CountElectrodesWithNude { get; set; }
        public string Rz { get; set; }

        public string Tostring()
        {
            var builder = new StringBuilder();
            builder.AppendLine(AllowableResistance);
            builder.AppendLine(FirstKcResult);
            builder.AppendLine(SecondKcResult);
            builder.AppendLine(FirstCalcValueResistivitySoil);
            builder.AppendLine(SecondCalcValueResistivitySoil);
            builder.AppendLine(ResistivitySoil);
            builder.AppendLine(FirstRResult);
            builder.AppendLine(SecondRResult);
            builder.AppendLine(ComparisonResistance);
            if (IsContinue)
            {
                builder.AppendLine(CountElectrodes);
                builder.AppendLine(FirstNude);
                builder.AppendLine(CountElectrodesWithNude);
                builder.AppendLine(Rz);
            }
            return builder.ToString().Trim();
        }

        public void SetMessage(string message)
        {

            _messages.Add(string.Format("{0} :>>> {1}", DateTime.Now, message));
        }

        public string GetMessages()
        {
            var stringBuilder = new StringBuilder();
            foreach (var message in _messages)
            {
                if (!string.IsNullOrEmpty(message))
                    stringBuilder.AppendLine(message);
            }
            return stringBuilder.ToString();
        }
    }
}
