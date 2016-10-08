using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Model;
using UnityEngine.UI;

public class InvestigatorItem : MonoBehaviour
{
    [SerializeField] private List<Text> _investigators;
    [SerializeField] private Text _investigatorsCount;

    public List<Toggle> ExpansionToggles { get; set; }

    private class Investigator
    {
        public string Name { get; set; }
        public int GameExpantion { get; set; }
    }

    private List<Investigator> _investigatorList;

    private void Start()
    {
        _investigatorList = new List<Investigator>
        {
            new Investigator {Name = "Amanda Sharpe", GameExpantion = 1},
            new Investigator {Name = "Ashcan Pete", GameExpantion = 1},
            new Investigator {Name = "Bob Jenkins", GameExpantion = 1},
            new Investigator {Name = "Carolyn Fern", GameExpantion = 1},
            new Investigator {Name = "Darrell Simmons", GameExpantion = 1},
            new Investigator {Name = "Dexter Drake", GameExpantion = 1},
            new Investigator {Name = "Gloria Goldberg", GameExpantion = 1},
            new Investigator {Name = "Harvey Walters", GameExpantion = 1},
            new Investigator {Name = "Jenny Barnes", GameExpantion = 1},
            new Investigator {Name = "Joe Diamond", GameExpantion = 1},
            new Investigator {Name = "Kate Winthrop", GameExpantion = 1},
            new Investigator {Name = "Mandy Thompson", GameExpantion = 1},
            new Investigator {Name = "Michael McGlen", GameExpantion = 1},
            new Investigator {Name = "Monterey Jack", GameExpantion = 1},
            new Investigator {Name = "Sister Mary", GameExpantion = 1},
            new Investigator {Name = "Vincent Lee", GameExpantion = 1},

            new Investigator {Name = "Diana Stanley", GameExpantion = 3},
            new Investigator {Name = "Jacqueline Fine", GameExpantion = 3},
            new Investigator {Name = "Jim Culver", GameExpantion = 3},
            new Investigator {Name = "Leo Anderson", GameExpantion = 3},
            new Investigator {Name = "Marie Lambeau", GameExpantion = 3},
            new Investigator {Name = "Mark Harrigan", GameExpantion = 3},
            new Investigator {Name = "Rita Young", GameExpantion = 3},
            new Investigator {Name = "Wilson Richards", GameExpantion = 3},

            new Investigator {Name = "Charlie Kane", GameExpantion = 5},
            new Investigator {Name = "Daisy Walker", GameExpantion = 5},
            new Investigator {Name = "Lily Chen", GameExpantion = 5},
            new Investigator {Name = "Lola Hayes", GameExpantion = 5},
            new Investigator {Name = "Luke Robinson", GameExpantion = 5},
            new Investigator {Name = "Rex Murphy", GameExpantion = 5},
            new Investigator {Name = "Tony Morgan", GameExpantion = 5},
            new Investigator {Name = "Wendy Adams", GameExpantion = 5},

            new Investigator {Name = "Agnes Baker", GameExpantion = 7},
            new Investigator {Name = "Akachi Onyele", GameExpantion = 7},
            new Investigator {Name = "Finn Edwards", GameExpantion = 7},
            new Investigator {Name = "George Barnaby", GameExpantion = 7},
            new Investigator {Name = "Hank Samson", GameExpantion = 7},
            new Investigator {Name = "Minh Thi Phan", GameExpantion = 7},
            new Investigator {Name = "Norman Withers", GameExpantion = 7},
            new Investigator {Name = "Patrice Hathaway", GameExpantion = 7},
            new Investigator {Name = "Roland Banks", GameExpantion = 7},
            new Investigator {Name = "Silas Marsh", GameExpantion = 7},
            new Investigator {Name = "Skids O'Toole", GameExpantion = 7},
            new Investigator {Name = "Tommy Muldoon", GameExpantion = 7},
            new Investigator {Name = "Trish Scarborough", GameExpantion = 7},
            new Investigator {Name = "Ursula Downs", GameExpantion = 7},
            new Investigator {Name = "William Yorick", GameExpantion = 7},
            new Investigator {Name = "Zoey Samaras", GameExpantion = 7},
        };
    }

    public void RandomInvestigators()
    {
        int count;
        int.TryParse(_investigatorsCount.text, out count);

        for (var i = 0; i < _investigators.Count; i++)
        {
            if (i < count)
            {
                _investigators[i].enabled = true;
                _investigators[i].text = GetInvestigator();
            }
            else
            {
                _investigators[i].enabled = false;
            }
        }
    }
    
    private string GetInvestigator()
    {
        var invest = _investigatorList.Where(i => i.GameExpantion == 1 || ExpansionToggles[i.GameExpantion-2].isOn).ToList();
        while (true)
        {
            var i = Random.Range(0, invest.Count);
            if (_investigators.Any(t => t.text == invest[i].Name)) continue;
            return invest[i].Name;
        }
    }
}
