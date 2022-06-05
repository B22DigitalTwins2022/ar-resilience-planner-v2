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

        private string m_CurrentUserStudyDirectoryPath;

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

            InitializeUserStudyFolderStructure();
            StartUserStudy();
        }

        public void Start()
        {
            
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
            m_CurrentUserStudyDirectoryPath = newUserStudyDirectoryPath;
            InitializeLogFiles();
        }

        private void InitializeLogFiles()
        {
            InitializeLogFile(continuousUserPositionLogFile);
        }

        private void InitializeLogFile(LogFile logFile)
        {
            // Should create the directory if it has not been created yet
            if (m_CurrentUserStudyDirectoryPath == "") { StartUserStudy(); }

            string logFilePath = logFile.FilePath(m_CurrentUserStudyDirectoryPath);

            // Construct the header string with the columns
            string headerString = "datetime,";
            for (int columnIndex = 0; columnIndex < logFile.columns.Length; columnIndex++)
            {
                headerString += logFile.columns[columnIndex];
                if (columnIndex != logFile.columns.Length-1) { headerString += ","; }
            }
            headerString += "\n";
            File.AppendAllText(logFilePath, headerString);
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

            public string FilePath(string dirPath)
            {
                return Path.Combine(dirPath, fileName + ".csv");
            }
        }

        /// <summary>
        /// The place where the position of the user and where they look to is stored
        /// </summary>
        public static LogFile continuousUserPositionLogFile = new LogFile()
        {
            fileName = "continuousUserPosition",
            columns = new string[] { "x", "y", "z", "lookX", "lookY", "lookZ", "lookAtObject"}
        };

        public static void Log(LogFile logFile, params object[] columns)
        {
            DataLogger logger = DataLogger.Instance;
            string logFilePath = logFile.FilePath(logger.m_CurrentUserStudyDirectoryPath);

            string timestamp = TimeStamp.Now;

            string logRowString = timestamp + ",";
            for (int columnIndex = 0; columnIndex < columns.Length; columnIndex++)
            {
                logRowString += columns[columnIndex];
                if (columnIndex != logFile.columns.Length - 1) { logRowString += ","; }
            }
            logRowString += "\n";
            File.AppendAllText(logFilePath, logRowString);
        }

        public void StopUserStudy()
        {
            // Store the final design in a json file
        }
    }

}