using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LanguageSplit
{
    public static Dictionary<Languages, Dictionary<string, string>> LoadCodeFromString(string downloasSource, string textToSplit)
    {
        Dictionary<Languages, Dictionary<string, string>> codex = new Dictionary<Languages, Dictionary<string, string>>();
        int lineNum = 0;
        string[] rows = textToSplit.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        bool first = true;

        var columnToIndex = new Dictionary<string, int>();

        foreach (var row in rows)
        {
            lineNum++;
            string[] cells = row.Split(';');

            if (first)
            {
                first = false;
                for (int i = 0; i < cells.Length; i++)
                {
                    columnToIndex[cells[i]] = i;
                }

                continue;
            }

            if(cells.Length != columnToIndex.Count)
            {
                Debug.Log($"Parsing CSV file {downloasSource} at line {lineNum}, column {cells.Length}, should be {columnToIndex.Count}");
                continue;
            }

            string langName = cells[columnToIndex["Idioma"]];
            Languages lang;

            try
            {
                lang = (Languages)Enum.Parse(typeof(Languages), langName);
            }
            catch(Exception e)
            {
                Debug.Log($"Parsing CSV file {downloasSource} at line {lineNum}, invalid languague {langName}");
                Debug.Log(e.ToString());
                continue;
            }

            string idName = cells[columnToIndex["ID"]];
            string text = cells[columnToIndex["Texto"]];

            if (!codex.ContainsKey(lang))
            {
                codex[lang] = new Dictionary<string, string>();
            }

            codex[lang][idName] = text;
        }
        return codex;
    }
}
