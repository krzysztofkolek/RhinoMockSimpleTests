namespace RihnoMockSimpleTests.CsvMap
{
    using CsvHelper.Configuration;
    using RihnoMockSimpleTests.CsvModel;

    public class CalculatorMap : CsvClassMap<CalculatorModel>
    {
        public override void CreateMap()
        {
            Map(m => m.NumberOne);
            Map(m => m.NumberTwo);
            Map(m => m.Add);
            Map(m => m.Multiply);
            Map(m => m.Devide);
            Map(m => m.Power);
            Map(m => m.Sqrt);
        }
    }
}
