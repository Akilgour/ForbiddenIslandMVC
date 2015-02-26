using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForbiddenIsland.Models.Interface
{
    public interface ITreasureCard
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Action { get; set; }
        MvcForbiddenIsland.Enum.Enums.TreasureCardType TreasureCardType { get; set; }
        int Order { get; set; }
    }
}
