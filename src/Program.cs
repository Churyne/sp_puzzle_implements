var a = Enumerable.Range(2, 98)
    .SelectMany(m => Enumerable.Range(m, 100 - m)
        .Select(n => (m, n, s: m + n, p: m * n)));
var (s, p) = (a.ToLookup(x => x.s), a.ToLookup(x => x.p));
var t = p.Where(g => g.Count() > 1)
    .Select(g => g.Where(x => s[x.s].Count() > 1 && s[x.s].All(y => p[y.p].Count() > 1)))
    .Where(v => v.Count() == 1)
    .SelectMany(v => v)
    .GroupBy(x => x.s)
    .Single(g => g.Count() == 1)
    .Single();
Console.WriteLine($"{t.s} = {t.m} + {t.n} , {t.p} = {t.m} * {t.n}");