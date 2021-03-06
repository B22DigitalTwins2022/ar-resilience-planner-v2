using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace ShapeReality
{
    public class SolutionsPanel : MonoBehaviour
    {
        public List<Solution> solutions;

        public GameObject solutionUIObjectPrefab;

        public RectTransform panel;

        [Header("Solution Description Panel")]
        public GameObject solutionDescriptionObject;
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI descriptionText;
        public Image picture;

        // Start is called before the first frame update
        public void Start()
        {
            InstantiateSolutions(solutions);

            HideSolutionDescription();
        }


        private void InstantiateSolutions(List<Solution> solutions)
        {
            for (int i=0; i< solutions.Count; i++)
            {
                Solution solution = solutions[i];

                SolutionUIObject solutionUIObject = Instantiate(solutionUIObjectPrefab, panel, false).GetComponent<SolutionUIObject>();
                solutionUIObject.solutionsPanel = this; // make sure the solution can call to the solutions panel to open the description
                solutionUIObject.solution = solution;
            }
        }

        /// <summary>
        /// Show the solution description use on hover 
        /// </summary>
        /// <param name="solutionToShowDescriptionOf"></param>
        public void ShowSolutionDescription(Solution solution)
        {
            if (solution == null) { return; }

            titleText.text = solution.title;
            descriptionText.text = solution.description;

            if (solution.picture == null)
            {
                picture.enabled = false;
            } else
            {
                picture.enabled = true;
                picture.sprite = solution.picture;
            }
            
            // Add the benefits and costs

            //
        }

        public void OnEnable()
        {
            solutionDescriptionObject.SetActive(true);
        }

        public void OnDisable()
        {
            solutionDescriptionObject.SetActive(false);
        }

        /// <summary>
        /// Hide the solution, use on hover ended
        /// </summary>
        public void HideSolutionDescription()
        {
            titleText.text = "";
            descriptionText.text = "";

            picture.enabled = false;
            
            //solutionDescriptionObject.SetActive(false);
        }
    }

}

