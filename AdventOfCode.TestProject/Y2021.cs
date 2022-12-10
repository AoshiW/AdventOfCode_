using AdventOfCode.Y2021;

namespace AdventOfCode.TestProject;

[TestClass]
public class Y2021
{
    [TestMethod] public async Task D01() => await Assert.That.TestDayAsync<D01>(1564, 1611);
    [TestMethod] public async Task D02() => await Assert.That.TestDayAsync<D02>(1692075, 1749524700);
    [TestMethod] public async Task D03() => await Assert.That.TestDayAsync<D03>(4174964, 4474944);
    [TestMethod] public async Task D04() => await Assert.That.TestDayAsync<D04>(23177, 6804);
    [TestMethod] public async Task D05() => await Assert.That.TestDayAsync<D05>(5197, 18605);
    [TestMethod] public async Task D06() => await Assert.That.TestDayAsync<D06>(352872ul, 1604361182149u);
    [TestMethod] public async Task D07() => await Assert.That.TestDayAsync<D07>(344605, 93699985);
    [TestMethod] public async Task D08() => await Assert.That.TestDayAsync<D08>(330, 1010472);
    [TestMethod] public async Task D09() => await Assert.That.TestDayAsync<D09>(480, 1045660);
    [TestMethod] public async Task D10() => await Assert.That.TestDayAsync<D10>(462693L, 3094671161L);
    [TestMethod] public async Task D11() => await Assert.That.TestDayAsync<D11>(1681, 276);
    //[TestMethod] public async Task D12() => await Assert.That.TestDayAsync<D12>(default!, default!);
    [TestMethod] public async Task D13() => await Assert.That.TestDayAsync<D13>("602", "CAFJHZCK");
    [TestMethod] public async Task D14() => await Assert.That.TestDayAsync<D14>(3058ul, 3447389044530u);
    //[TestMethod] public async Task D15() => await Assert.That.TestDayAsync<D15>(default!, default!);
    [TestMethod] public async Task D16() => await Assert.That.TestDayAsync<D16>(893uL, 4358595186090u);
    [TestMethod] public async Task D17() => await Assert.That.TestDayAsync<D17>(10878, 4716);
    [TestMethod] public async Task D18() => await Assert.That.TestDayAsync<D18>(4347, 4721);
    //[TestMethod] public async Task D19() => await Assert.That.TestDayAsync<D19>(default!, default!);
    [TestMethod] public async Task D20() => await Assert.That.TestDayAsync<D20>(5097, 17987);
    [TestMethod] public async Task D21() => await Assert.That.TestDayAsync<D21>(412344L, 214924284932572);
    [TestMethod] public async Task D22() => await Assert.That.TestDayAsync<D22>(596598L, default!);
    //[TestMethod] public async Task D23() => await Assert.That.TestDayAsync<D23>(11536, default!);
    //[TestMethod] public async Task D24() => await Assert.That.TestDayAsync<D24>(default!, default!);
    [TestMethod] public async Task D25() => await Assert.That.TestDayAsync<D25>(406, default(int));
}
