#pragma warning disable 0649  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryContents : MonoBehaviour
{
    [SerializeField] ReturnDelegate rd;

    public MassContents ReturnContents(StoryList story)
    {
        switch (story)
        {
            case StoryList.nullStory:
                return new MassContents(rd.NullStory);
            case StoryList.healHP:
                return new MassContents(rd.HealHP);
            case StoryList.shopping:
                return new MassContents(rd.Shopping);
            case StoryList.helpPeople:
                return new MassContents(rd.HelpPeople);
            case StoryList.callbattle:
                return new MassContents(rd.CallBattle);
            default:
                return new MassContents(rd.NullStory);
        }
    }
}
