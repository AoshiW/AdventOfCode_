using AdventOfCode.Y2015;

namespace AdventOfCode.TestProject;

[TestClass]
public class Y2015
{
    [TestMethod] public async Task D01() => await Assert.That.TestDayAsync<D01>(232, 1783);
    [TestMethod] public async Task D02() => await Assert.That.TestDayAsync<D02>(1598415, 3812909);
    [TestMethod] public async Task D03() => await Assert.That.TestDayAsync<D03>(2572, 2631);
    [TestMethod] public async Task D04() => await Assert.That.TestDayAsync<D04>(117946, 3938038);
    [TestMethod] public async Task D05() => await Assert.That.TestDayAsync<D05>(258, 53);
    [TestMethod] public async Task D06() => await Assert.That.TestDayAsync<D06>(543903, 14687245);
    [TestMethod] public async Task D07() => await Assert.That.TestDayAsync<D07>(16076, 2797);
    [TestMethod] public async Task D08() => await Assert.That.TestDayAsync<D08>(1371, 2117);
    //[TestMethod] public async Task D09() => await Assert.That.TestDayAsync<D09>(default!, default!);
    [TestMethod] public async Task D10() => await Assert.That.TestDayAsync<D10>(329356, 4666278);
    [TestMethod] public async Task D11() => await Assert.That.TestDayAsync<D11>("hepxxyzz", "heqaabcc");
    [TestMethod] public async Task D12() => await Assert.That.TestDayAsync<D12>(191164, 87842);
    [TestMethod] public async Task D13() => await Assert.That.TestDayAsync<D13>(709, 668);
    [TestMethod] public async Task D14() => await Assert.That.TestDayAsync<D14>(2655, 1059);
    //[TestMethod] public async Task D15() => await Assert.That.TestDayAsync<D15>(default!, default!);
    [TestMethod] public async Task D16() => await Assert.That.TestDayAsync<D16>(40, 241);
    [TestMethod] public async Task D17() => await Assert.That.TestDayAsync<D17>(654, 57);
    [TestMethod] public async Task D18() => await Assert.That.TestDayAsync<D18>(768, 781);
    [TestMethod] public async Task D19() => await Assert.That.TestDayAsync<D19>(576, default!);
    [TestMethod] public async Task D20() => await Assert.That.TestDayAsync<D20>(776160, 786240);
    //[TestMethod] public async Task D21() => await Assert.That.TestDayAsync<D21>(default!, default!);
    //[TestMethod] public async Task D22() => await Assert.That.TestDayAsync<D22>(default!, default!);
    [TestMethod] public async Task D23() => await Assert.That.TestDayAsync<D23>(307, 160);
    [TestMethod] public async Task D24() => await Assert.That.TestDayAsync<D24>(10439961859, default!);
    [TestMethod] public async Task D25() => await Assert.That.TestDayAsync<D25>(2650453L, default(long));
}
