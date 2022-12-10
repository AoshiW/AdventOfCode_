using AdventOfCode.Y2022;

namespace AdventOfCode.TestProject;

[TestClass]
public class Y2022
{
    [TestMethod] public async Task D01() => await Assert.That.TestDayAsync<D01>(69836, 207968);
    [TestMethod] public async Task D02() => await Assert.That.TestDayAsync<D02>(15337, 11696);
    [TestMethod] public async Task D03() => await Assert.That.TestDayAsync<D03>(8401, 2641);
    [TestMethod] public async Task D04() => await Assert.That.TestDayAsync<D04>(573, 867);
    [TestMethod] public async Task D05() => await Assert.That.TestDayAsync<D05>("MQTPGLLDN", "LVZPSTTCZ");
    [TestMethod] public async Task D06() => await Assert.That.TestDayAsync<D06>(1920, 2334);
    [TestMethod] public async Task D07() => await Assert.That.TestDayAsync<D07>(1667443, 8998590);
    [TestMethod] public async Task D08() => await Assert.That.TestDayAsync<D08>(1560, 252000);
    [TestMethod] public async Task D09() => await Assert.That.TestDayAsync<D09>(6090, 2566);
    [TestMethod] public async Task D10() => await Assert.That.TestDayAsync<D10>("13760", "RFKZCPEF");
    //[TestMethod] public async Task D11() => await Assert.That.TestDayAsync<D11>(default, default);
    //[TestMethod] public async Task D12() => await Assert.That.TestDayAsync<D12>(default, default);
    //[TestMethod] public async Task D13() => await Assert.That.TestDayAsync<D13>(default, default);
    //[TestMethod] public async Task D14() => await Assert.That.TestDayAsync<D14>(default, default);
    //[TestMethod] public async Task D15() => await Assert.That.TestDayAsync<D15>(default, default);
    //[TestMethod] public async Task D16() => await Assert.That.TestDayAsync<D16>(default, default);
    //[TestMethod] public async Task D17() => await Assert.That.TestDayAsync<D17>(default, default);
    //[TestMethod] public async Task D18() => await Assert.That.TestDayAsync<D18>(default, default);
    //[TestMethod] public async Task D19() => await Assert.That.TestDayAsync<D19>(default, default);
    //[TestMethod] public async Task D20() => await Assert.That.TestDayAsync<D20>(default, default);
    //[TestMethod] public async Task D21() => await Assert.That.TestDayAsync<D21>(default, default);
    //[TestMethod] public async Task D22() => await Assert.That.TestDayAsync<D22>(default, default);
    //[TestMethod] public async Task D23() => await Assert.That.TestDayAsync<D23>(default, default);
    //[TestMethod] public async Task D24() => await Assert.That.TestDayAsync<D24>(default, default);
    //[TestMethod] public async Task D25() => await Assert.That.TestDayAsync<D25>(default, default(long));
}
