using InstagramBloksParser;

static class Program
{
    static void Main(string[] args)
    {
        string Input1 = @"(bk.action.array.Make, (bk.action.i64.Const, 188679189600026), (bk.action.i64.Const, 188679189600056), (bk.action.i64.Const, 188679189600053), (bk.action.i64.Const, 188679189600055), \\\""2ad97863--47c7-b86d-\\\"", \\\""-a601-42d5--\\\"", \\\""harm_f\\\"", (bk.action.i32.Const, 36707139), (bk.action.i64.Const, 188679189600061))";
        string Input2 = @"(bk.action.core.TakeLast, (bk.action.bloks.WriteGlobalConsistencyStore, \""CAA_LOGIN_FORM:typeahead_list_shown:0\"", (bk.action.bool.Const, false)), (bk.action.bloks.RemoveChild, \""ux8c01:26\"", \""ux8c01:55\"", (bk.action.context.Get)))";
        string Input3 = @"(bk.action.map.Make,(bk.action.array.Make, \""login_type\"", \""login_source\""),(bk.action.array.Make, \""Password\"", \""Login\""))";
        PrintTree(BloksParser.Parse(Input1));
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        PrintTree(BloksParser.Parse(Input2));
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        PrintTree(BloksParser.Parse(Input3));


        Console.Read();
    }
    static void PrintTree(BloksNode node, int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + node.Key);
        foreach (var child in node.Children)
        {
            PrintTree(child, indent + 2);
        }
    }
}