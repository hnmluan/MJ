using Ink.Runtime;
using System;
using UnityEngine;

public class InkExternalFunctions
{
    public void Bind(Story story, Animator emoteAnimator)
    {
        story.BindExternalFunction("playEmote", (string emoteName) => PlayEmote(emoteName, emoteAnimator));
        story.BindExternalFunction("rewardItem", (string itemName, int quantity) => RewardItem(itemName, quantity));
        story.BindExternalFunction("switchTask", () => TaskManager.Instance.Switch2NextTaskEnumCode());
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("playEmote");
        story.UnbindExternalFunction("rewardItem");
        story.UnbindExternalFunction("switchTask");
    }

    public void PlayEmote(string emoteName, Animator emoteAnimator)
    {
        if (emoteAnimator != null) emoteAnimator.Play(emoteName);
        else Debug.LogWarning("Tried to play emote, but emote animator was " + "not initialized when entering dialogue mode.");
    }
    public void RewardItem(string itemName, int quantity)
    {
        RewardItemUISpawner.Instance.ClearRewardItemUI();

        ItemCode itemCode;
        if (!Enum.TryParse(itemName, out itemCode))
        {
            Debug.Log("Don't find " + itemName);
            return;
        }
        Inventory.Instance.AddItem(itemCode, quantity);
        RewardItemUISpawner.Instance.SpawnRewardItemUI(itemCode, quantity);
        UIReward.Instance.Open();
        Debug.Log("Reward x" + quantity + " " + itemName);
    }

}
