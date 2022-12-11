using AdventOfCode.Y2020;

namespace AdventOfCode.TestProject;

[TestClass]
public class Y2020
{
    [TestMethod] public async Task D01() => await Assert.That.TestDayAsync<D01>(1019571, 100655544);
    [TestMethod] public async Task D02() => await Assert.That.TestDayAsync<D02>(483, 482);
    [TestMethod] public async Task D03() => await Assert.That.TestDayAsync<D03>(247L, 2983070376L);
    [TestMethod] public async Task D04() => await Assert.That.TestDayAsync<D04>(256, 198);
    [TestMethod] public async Task D05() => await Assert.That.TestDayAsync<D05>(996, 671);
    [TestMethod] public async Task D06() => await Assert.That.TestDayAsync<D06>(6585, 3276);
    [TestMethod] public async Task D07() => await Assert.That.TestDayAsync<D07>(302, 4165);
    [TestMethod] public async Task D08() => await Assert.That.TestDayAsync<D08>(1915, 944);
    [TestMethod] public async Task D09() => await Assert.That.TestDayAsync<D09>(14144619L, 1766397L);
    [TestMethod] public async Task D10() => await Assert.That.TestDayAsync<D10>(2400L, 338510590509056);
    [TestMethod] public async Task D11() => await Assert.That.TestDayAsync<D11>(2238, 2013);
    [TestMethod] public async Task D12() => await Assert.That.TestDayAsync<D12>(319, 50157);
    [TestMethod] public async Task D13() => await Assert.That.TestDayAsync<D13>(2305L, default!);
    [TestMethod] public async Task D14() => await Assert.That.TestDayAsync<D14>(11501064782628u, 5142195937660u);
    [TestMethod] public async Task D15() => await Assert.That.TestDayAsync<D15>(232, 18929178);
    [TestMethod] public async Task D16() => await Assert.That.TestDayAsync<D16>(20013L, default!);
    //[TestMethod] public async Task D17() => await Assert.That.TestDayAsync<D17>(default!, default!);
    [TestMethod] public async Task D18() => await Assert.That.TestDayAsync<D18>(11076907812171, 283729053022731);
    [TestMethod] public async Task D19() => await Assert.That.TestDayAsync<D19>(205, default!);
    //[TestMethod] public async Task D20() => await Assert.That.TestDayAsync<D20>(default!, default!);
    //[TestMethod] public async Task D21() => await Assert.That.TestDayAsync<D21>(default!, default!);
    [TestMethod] public async Task D22() => await Assert.That.TestDayAsync<D22>(32856, 33805);
    [TestMethod] public async Task D23() => await Assert.That.TestDayAsync<D23>(28946753L, 519044017360);
    [TestMethod] public async Task D24() => await Assert.That.TestDayAsync<D24>(356, 3887);
    [TestMethod] public async Task D25() => await Assert.That.TestDayAsync<D25>(18608573L, default(long));
}
