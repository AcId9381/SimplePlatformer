using Godot;
using System;

public partial class GameManager : Node
{
    private Label _scoreLabel;
    public uint Score = 0;

    public override void _Ready()
    {
        base._Ready();
        _scoreLabel = GetNode<Label>("ScoreLabel");
    }

    public void AddPoint()
    {
        Score += 1;
        _scoreLabel.Text = $"You collected {Score} coins.";
    }
}
