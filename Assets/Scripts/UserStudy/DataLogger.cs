using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace ShapeReality
{
    /// <summary>
    /// Create a timestamped folder per user study
    /// </summary>
    public class DataLogger : MonoBehaviour
    {
        // Singleton behaviour
        private static DataLogger _instance;
        public static DataLogger Instance { get { return _instance; } }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this);
            }
            else
            {
                _instance = this;
            }
        }

        public void Start()
        {
            InitializeUserStudyFolderStructure();
            StartUserStudy();
        }

        private void InitializeUserStudyFolderStructure()
        {
            string path = Constants.Paths.userStudyPath;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void StartUserStudy()
        {
            // Create the folder and create a csv with all of the logged data

            // Multiple csv's should be created

            string timestamp = TimeStamp.Now;
            string directoryName = timestamp + "_userstudy";
            string newUserStudyDirectoryPath = Path.Combine(Constants.Paths.userStudyPath, directoryName);

            Directory.CreateDirectory(newUserStudyDirectoryPath);

            InitializeLogFiles();
        }

        private void InitializeLogFiles()
        {
            InitializeLogFile(continuousUserPositionLogFile);
        }

        private void InitializeLogFile(LogFile logFile)
        {

        }

        public struct LogFile
        {
            /// <summary>
            /// Filename to use, .csv will be added.
            /// So "locomotion" becomes "locomotion.csv"
            /// </summary>
            public string fileName;
            /// <summary>
            /// Columns that should be added, datetime is added by default, so
            /// doesn't have to be added here
            /// </summary>
            public string[] columns;
        }

        /// <summary>
        /// The place where the position of the user and where they look to is stored
        /// </summary>
        public LogFile continuousUserPositionLogFile = new LogFile()
        {
            fileName = "continuousUserPosition",
            columns = new string[] { "x", "y", "z", "lookX", "lookY", "lookZ", "lookAtObject"}
        };

        public void Log(LogFile logTo, params string[] columns)
        {

        }

        public void StopUserStudy()
        {
            // Store the final design in a json file
        }
    }

}
