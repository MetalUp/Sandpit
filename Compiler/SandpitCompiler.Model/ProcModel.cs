﻿namespace SandpitCompiler.Model;

public class ProcModel : IModel {
    public ProcModel(string id, IEnumerable<IModel> parms, IEnumerable<IModel> vars) {
        ID = id;
        Parms = parms;
        Vars = vars;
    }

    private string ID { get; }
    public IEnumerable<IModel> Parms { get; }

    private IEnumerable<IModel> Vars { get; }

    public override string ToString() =>
        $@"public static void {ID}({ParmsAsString()}) {{
          {VarsAsString()}
        }}".Trim();

    public bool HasMain => false;

    private string VarsAsString() => string.Join("\r\n  ", Vars.Select(v => v.ToString())).Trim();
    private string ParmsAsString() => string.Join(", ", Parms.Select(v => v.ToString())).Trim();
}