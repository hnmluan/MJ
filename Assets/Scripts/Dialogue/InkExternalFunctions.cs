using Ink.Runtime;
using UnityEngine;

public class InkExternalFunctions
{
    public void Bind(Story story, Animator emoteAnimator)
    {
        if (emoteAnimator != null) story.BindExternalFunction("playEmote", (string emoteName) => PlayEmote(emoteName, emoteAnimator));
        story.BindExternalFunction("rewardItem", (string itemCode, int quantity) => RewardItem(itemCode, quantity));
        story.BindExternalFunction("rewardWeapon", (string weaponCode, int level) => RewardWeapon(weaponCode, level));
        story.BindExternalFunction("showTaskPanel", () => UITask.Instance.Open());
        story.BindExternalFunction("switch2NextTask", () => Task.Instance.Switch2NextTask());
        story.BindExternalFunction("doneCriteriaTask", (int criteria) => Task.Instance.DoneCriteriaTask(criteria));
        story.BindExternalFunction("guide", () => DialogueManager.Instance.ShowGuide());
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("playEmote");
        story.UnbindExternalFunction("rewardItem");
        story.UnbindExternalFunction("rewardWeapon");
        story.UnbindExternalFunction("showTaskPanel");
        story.UnbindExternalFunction("switch2NextTask");
        story.UnbindExternalFunction("doneCriteriaTask");
        story.UnbindExternalFunction("guide");
    }

    public void PlayEmote(string emoteName, Animator emoteAnimator)
    {
        if (emoteAnimator != null) emoteAnimator.Play(emoteName);
        else Debug.LogWarning("Tried to play emote, but emote animator was " + "not initialized when entering dialogue mode.");
    }

    public void RewardItem(string itemCode, int quantity)
    {
        RewardItemUISpawner.Instance.Clear();

        ItemCode code = ItemCodeParser.FromString(itemCode);

        if (code == ItemCode.NoItem)
        {
            Debug.Log("Dont found information " + itemCode + " for reward item");
            return;
        }

        RewardItemUISpawner.Instance.Spawn(code, quantity);

        Inventory.Instance.AddItem(code, quantity);

        UIReward.Instance.Open();
    }

    public void RewardWeapon(string weaponCode, int level)
    {
        RewardItemUISpawner.Instance.Clear();

        WeaponCode code = WeaponCodeParser.FromString(weaponCode);

        if (code == WeaponCode.NoWeapon)
        {
            Debug.Log("Dont found information " + weaponCode + " for reward item");
            return;
        }

        RewardItemUISpawner.Instance.Spawn(code, level);

        Armory.Instance.AddItem(code, 1, level);

        UIReward.Instance.Open();
    }
}
