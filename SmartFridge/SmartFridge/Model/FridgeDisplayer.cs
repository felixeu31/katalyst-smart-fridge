using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFridge.Model
{
    public class FridgeDisplayer : IFridgeDisplayer
    {
        private readonly IPrinter _printer;

        public FridgeDisplayer(IPrinter printer)
        {
            _printer = printer;
        }

        public void ShowDisplay(IReadOnlyCollection<Item> items, DateTime currentDate)
        {
            if (!items.Any())
                _printer.Print("Fridge is empty");

            foreach (var item in items)
            {
                _printer.Print($"{item.Name()}: {item.CalculateRemainingDays(currentDate)} days remaining");
            }
        }
    }
}
