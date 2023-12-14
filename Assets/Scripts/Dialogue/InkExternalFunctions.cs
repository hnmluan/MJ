using Ink.Runtime;
using UnityEngine;

public class InkExternalFunctions
{
    public void Bind(Story story, Animator emoteAnimator)
    {
        if (emoteAnimator != null) story.BindExternalFunction("playEmote", (string emoteName) => PlayEmote(emoteName, emoteAnimator));
        story.BindExternalFunction("rewardItem", (string itemName, int quantity) => RewardItem(itemName, quantity));
        story.BindExternalFunction("switchTask", () => Task.Instance.Switch2NextTask());
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
        RewardItemUISpawner.Instance.Clear();

        ItemCode itemCode = ItemCodeParser.FromString(itemName);

        if (itemCode == ItemCode.NoItem)
        {
            Debug.Log("Dont found information " + itemName + " for reward item");
            return;
        }

        RewardItemUISpawner.Instance.Spawn(itemCode, quantity);

        Inventory.Instance.AddItem(itemCode, quantity);

        UIReward.Instance.Open();
    }
}
