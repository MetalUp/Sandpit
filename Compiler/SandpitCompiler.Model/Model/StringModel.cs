using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandpitCompiler.Model.Model
{
    public class StringModel : IModel
    {
        private readonly string val;

        public StringModel(string val) {
            this.val = val;
        }

        public bool HasMain { get; } = false;
        public override string ToString() => val;
    }
}
