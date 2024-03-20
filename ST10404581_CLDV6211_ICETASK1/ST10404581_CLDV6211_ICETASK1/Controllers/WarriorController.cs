using Microsoft.AspNetCore.Mvc;
using ST10404581_CLDV6211_ICETASK1.Models;

namespace ST10404581_CLDV6211_ICETASK1.Controllers
{
    public class WarriorController : Controller
    {
        private static List<Warrior> _warriors = new List<Warrior>();
        public IActionResult Index()
        {
            return View(_warriors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Warrior warrior)
        {
            if (ModelState.IsValid)
            {
                warrior.Id = _warriors.Count + 1;
                _warriors.Add(warrior);
                return RedirectToAction("Index");
            }
            return View(warrior);
        }

        public IActionResult Edit(int ID)
        {
            Warrior warrior = _warriors.FirstOrDefault(w => w.Id == ID);
            if (warrior == null)
            {
                return NotFound();
            }
            return View(warrior);
        }

        [HttpPost]
        public IActionResult Edit(Warrior warrior)
        {
            if (ModelState.IsValid)
            {
                Warrior existingWarrior = _warriors.FirstOrDefault(w =>w.Id == warrior.Id);
                if (existingWarrior == null)
                {
                    existingWarrior.Name = warrior.Name;
                    existingWarrior.DateJoined = warrior.DateJoined;
                    existingWarrior.TimesSummoned = warrior.TimesSummoned;

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            return View(warrior);
        }

        public IActionResult Delete(int ID)
        {
            Warrior warriorToDelete = _warriors.FirstOrDefault(w => w.Id == ID);
            if (warriorToDelete == null)
            {
                return NotFound();
            }
            return View(warriorToDelete);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmerd(int ID)
        {
            Warrior warriorToDelete = _warriors.FirstOrDefault(w => w.Id == ID);
            if (warriorToDelete == null)
            {
                _warriors.Remove(warriorToDelete);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
