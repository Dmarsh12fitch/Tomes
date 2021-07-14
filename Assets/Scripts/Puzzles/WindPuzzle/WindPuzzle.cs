using System.Collections.Generic;
using UnityEngine;

namespace Puzzles.WindPuzzle
{
    public class WindPuzzle : MonoBehaviour
    {
        // Summary of the puzzle: the player needs to stop the axe trap by taking each object and move it onto the sigil
        // that has a matching element using the wind spell. 
        public TrapAxe axeTrap;

       [SerializeField] private List<Sigil> sigilList = new List<Sigil>();
        // Start is called before the first frame update
        void Start()
        {
            axeTrap = GameObject.FindGameObjectWithTag("Axe Trap").GetComponent<TrapAxe>();
        }

        // Update is called once per frame
        void Update()
        {
            // checks if every sigil is activated
            bool allActivated = true;
            foreach (Sigil sigil in sigilList)
            {
                if (!sigil.activated)
                {
                    allActivated = false;
                    break;
                }
            }
            // if all sigials are activated then the axe trap is stopped
            axeTrap.axeToggle = !allActivated;
        }
    }
}
