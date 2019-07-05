using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1.Model.ReuseableThings
{
    public abstract class Model
    {
        //чтобы модель знала, что приложение запущено
        public virtual void onLoaded() => Loaded?.Invoke(this, EventArgs.Empty);

        public event EventHandler Loaded;
    }
}
