using AdventOfCode.Y2016;

namespace AdventOfCode.TestProject;

[TestClass]
public class Y2016
{
    [TestMethod] public async Task D01() => await Assert.That.TestDayAsync<D01>(236, 182);
    [TestMethod] public async Task D02() => await Assert.That.TestDayAsync<D02>("78985", "57DD8");
    [TestMethod] public async Task D03() => await Assert.That.TestDayAsync<D03>(917, 1649);
    [TestMethod] public async Task D04() => await Assert.That.TestDayAsync<D04>(278221, 267);
    [TestMethod] public async Task D05() => await Assert.That.TestDayAsync<D05>("f97c354d", "863dde27");
    [TestMethod] public async Task D06() => await Assert.That.TestDayAsync<D06>("agmwzecr", "owlaxqvq");
    [TestMethod] public async Task D07() => await Assert.That.TestDayAsync<D07>(110, 242);
    [TestMethod] public async Task D08() => await Assert.That.TestDayAsync<D08>("121", "RURUCEOEIL");
    [TestMethod] public async Task D09() => await Assert.That.TestDayAsync<D09>(183269L, 11317278863);
    [TestMethod] public async Task D10() => await Assert.That.TestDayAsync<D10>(73, 3965);
    //[TestMethod] public async Task D11() => await Assert.That.TestDayAsync<D11>(default!, default!);
    [TestMethod] public async Task D12() => await Assert.That.TestDayAsync<D12>(317993, 9227647);
    [TestMethod] public async Task D13() => await Assert.That.TestDayAsync<D13>(92, 124);
    [TestMethod] public async Task D14() => await Assert.That.TestDayAsync<D14>(35186, 22429);
    [TestMethod] public async Task D15() => await Assert.That.TestDayAsync<D15>(203660, 2408135);
    [TestMethod] public async Task D16() => await Assert.That.TestDayAsync<D16>("10100011010101011", "01010001101011001");
    //[TestMethod] public async Task D17() => await Assert.That.TestDayAsync<D17>(default!, default!);
    [TestMethod] public async Task D18() => await Assert.That.TestDayAsync<D18>(1974, 19991126);
    [TestMethod] public async Task D19() => await Assert.That.TestDayAsync<D19>(1816277, 1410967);
    [TestMethod] public async Task D20() => await Assert.That.TestDayAsync<D20>(14975795U, 101U);
    [TestMethod] public async Task D21() => await Assert.That.TestDayAsync<D21>("gbhafcde", default!);
    [TestMethod] public async Task D22() => await Assert.That.TestDayAsync<D22>(1003, default!);
    [TestMethod] public async Task D23() => await Assert.That.TestDayAsync<D23>(12480, 479009040);
    //[TestMethod] public async Task D24() => await Assert.That.TestDayAsync<D24>(default!, default!);
    //[TestMethod] public async Task D25() => await Assert.That.TestDayAsync<D25>(default!, default!);
}