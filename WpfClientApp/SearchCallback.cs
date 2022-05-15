
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfClientApp
{
    class SearchCallback : ServiceReference2.ISearchToDoServiceCallback

    {
        public SearchCallback(Action<ServiceReference2.ToDo []> display)
        {
            Display = display;
        }
        public Action<ServiceReference2.ToDo []> Display { get; }


        public void SearchResult(ServiceReference2.ToDo [] result)
        {
            Display(result);
        }
    }
}
