namespace RihnoMockSimpleTests
{
    using NUnit.Framework;
    using Rhino.Mocks;
    using RihnoMockSimpleTests.CsvModel;
    using RihnoMockSimpleTests.Custom;
    using SimpleLogic;

    [TestFixture]
    public class CalculatorTest : BaseTest<CalculatorModel, CalculatorTest>
    {
        #region Private members
        private ICalculator _calculator { get; set; }
        #endregion Private members

        #region Constructors
        public CalculatorTest()
        {
        }
        #endregion Constructors

        #region Abstract layer
        public override string GetDataFileName()
        {
            return "CalculatorData.csv";
        }

        public override TestContext GetTestContext()
        {
            return TestContext.CurrentContext;
        }
        #endregion Abstract layer

        #region Test preparation
        [SetUp]
        public void Setup()
        {
            _calculator = MockRepository.GenerateMock<ICalculator>();
        }
        #endregion Test preparation

        #region Tests
        [Test, Order(1), Category("CalculatorTest"), TestCaseSource("GetTestData")]
        public void TestAdd(CalculatorModel testData)
        {
            // ARRANGE
            _calculator.Expect(c => c.Add(testData.NumberOne, testData.NumberTwo)).Return(testData.Add);

            // ACT
            var result = _calculator.Add(testData.NumberOne, testData.NumberTwo);

            // ASSERT
            Assert.AreEqual(result, testData.Add);
        }

        [Test, Order(2), Category("CalculatorTest"), TestCaseSource("GetTestData")]
        public void TestMultiply(CalculatorModel testData)
        {
            // ARRANGE
            _calculator.Expect(c => c.Multiply(testData.NumberOne, testData.NumberTwo)).Return(testData.Add);

            // ACT
            var result = _calculator.Multiply(testData.NumberOne, testData.NumberTwo);

            // ASSERT
            Assert.AreEqual(result, testData.Multiply);
        }

        [Test, Order(3), Category("CalculatorTest"), TestCaseSource("GetTestData")]
        public void TestDevide(CalculatorModel testData)
        {
            // ARRANGE
            _calculator.Expect(c => c.Devide(testData.NumberOne, testData.NumberTwo)).Return(testData.Add);

            // ACT
            var result = _calculator.Devide(testData.NumberOne, testData.NumberTwo);

            // ASSERT
            Assert.AreEqual(result, testData.Devide);
        }

        [Test, Order(4), Category("CalculatorTest"), TestCaseSource("GetTestData")]
        public void TestPower(CalculatorModel testData)
        {
            // ARRANGE
            _calculator.Expect(c => c.Power(testData.NumberOne, testData.NumberTwo)).Return(testData.Add);

            // ACT
            var result = _calculator.Power(testData.NumberOne, testData.NumberTwo);

            // ASSERT
            Assert.AreEqual(result, testData.Add);
        }

        [Test, Order(5), Category("CalculatorTest"), TestCaseSource("GetTestData")]
        public void TestSqrt(CalculatorModel testData)
        {
            // ARRANGE
            _calculator.Expect(c => c.Sqrt(testData.NumberOne)).Return(testData.Add);

            // ACT
            var result = _calculator.Sqrt(testData.NumberOne);

            // ASSERTRa
            Assert.AreEqual(result, testData.Sqrt);
        }
        #endregion Tests
    }
}
