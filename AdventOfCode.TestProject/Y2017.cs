using AdventOfCode.Y2017;

namespace AdventOfCode.TestProject;

[TestClass]
public class Y2017
{
    [TestMethod] public async Task D01() => await Assert.That.TestDayAsync<D01>(1175, 1166);
    [TestMethod] public async Task D02() => await Assert.That.TestDayAsync<D02>(54426, 333);
    [TestMethod] public async Task D03() => await Assert.That.TestDayAsync<D03>(430, 312453);
    [TestMethod] public async Task D04() => await Assert.That.TestDayAsync<D04>(466, 251);
    [TestMethod] public async Task D05() => await Assert.That.TestDayAsync<D05>(325922, 24490906);
    [TestMethod] public async Task D06() => await Assert.That.TestDayAsync<D06>(4074, 2793);
    //[TestMethod] public async Task D07() => await Assert.That.TestDayAsync<D07>(default!, default!);
    [TestMethod] public async Task D08() => await Assert.That.TestDayAsync<D08>(7787, 8997);
    //[TestMethod] public async Task D09() => await Assert.That.TestDayAsync<D09>(default!, default!);
    [TestMethod] public async Task D10() => await Assert.That.TestDayAsync<D10>(9656, default!);
    [TestMethod] public async Task D11() => await Assert.That.TestDayAsync<D11>(743, default!);
    [TestMethod] public async Task D12() => await Assert.That.TestDayAsync<D12>(152, 186);
    //[TestMethod] public async Task D13() => await Assert.That.TestDayAsync<D13>(default!, default!);
    //[TestMethod] public async Task D14() => await Assert.That.TestDayAsync<D14>(default!, default!);
    [TestMethod] public async Task D15() => await Assert.That.TestDayAsync<D15>(567, 323);
    //[TestMethod] public async Task D16() => await Assert.That.TestDayAsync<D16>(default!, default!);
    [TestMethod] public async Task D17() => await Assert.That.TestDayAsync<D17>(600, 31220910);
    //[TestMethod] public async Task D18() => await Assert.That.TestDayAsync<D18>(default!, default!);
    [TestMethod] public async Task D19() => await Assert.That.TestDayAsync<D19>("LXWCKGRAOY", "17302");
    //[TestMethod] public async Task D20() => await Assert.That.TestDayAsync<D20>(default!, default!);
    //[TestMethod] public async Task D21() => await Assert.That.TestDayAsync<D21>(default!, default!);
    //[TestMethod] public async Task D22() => await Assert.That.TestDayAsync<D22>(default!, default!);
    //[TestMethod] public async Task D23() => await Assert.That.TestDayAsync<D23>(default!, default!);
    //[TestMethod] public async Task D24() => await Assert.That.TestDayAsync<D24>(default!, default!);
    [TestMethod] public async Task D25() => await Assert.That.TestDayAsync<D25>(2526, default(int));
}
