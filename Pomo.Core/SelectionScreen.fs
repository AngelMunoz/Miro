namespace Pomo.Core

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Myra
open Myra.Graphics2D.UI

type SelectionScreen(game: Game) =
  let mutable desktop: Desktop = null
  let mutable initialized = false

  member this.Initialize() =
    if not initialized then
      MyraEnvironment.Game <- game
      
      // Create the main vertical panel
      let mainPanel = new VerticalStackPanel()
      mainPanel.Spacing <- 20
      mainPanel.HorizontalAlignment <- HorizontalAlignment.Center
      mainPanel.VerticalAlignment <- VerticalAlignment.Center

      // Add a title label
      let titleLabel = new Label()
      titleLabel.Text <- "Selection Screen"
      titleLabel.TextColor <- Color.White

      // Create a menu with selection buttons
      let newGameButton = new Button()
      newGameButton.Content <- new Label(Text = "New Game")
      newGameButton.Width <- 200
      newGameButton.Height <- 50
      
      let loadGameButton = new Button()
      loadGameButton.Content <- new Label(Text = "Load Game")
      loadGameButton.Width <- 200
      loadGameButton.Height <- 50
      
      let settingsButton = new Button()
      settingsButton.Content <- new Label(Text = "Settings")
      settingsButton.Width <- 200
      settingsButton.Height <- 50
      
      let exitButton = new Button()
      exitButton.Content <- new Label(Text = "Exit")
      exitButton.Width <- 200
      exitButton.Height <- 50

      // Add click handlers (placeholders for now)
      newGameButton.Click.Add(fun _ -> 
        System.Console.WriteLine("New Game clicked")
      )
      
      loadGameButton.Click.Add(fun _ -> 
        System.Console.WriteLine("Load Game clicked")
      )
      
      settingsButton.Click.Add(fun _ -> 
        System.Console.WriteLine("Settings clicked")
      )
      
      exitButton.Click.Add(fun _ -> 
        System.Console.WriteLine("Exit clicked")
        game.Exit()
      )

      // Add widgets to the main panel
      mainPanel.Widgets.Add(titleLabel)
      mainPanel.Widgets.Add(newGameButton)
      mainPanel.Widgets.Add(loadGameButton)
      mainPanel.Widgets.Add(settingsButton)
      mainPanel.Widgets.Add(exitButton)

      // Create and setup the desktop
      desktop <- new Desktop()
      desktop.Root <- mainPanel
      
      initialized <- true

  member this.Update() =
    if initialized then
      // Desktop handles its own input updates
      ()

  member this.Draw() =
    if initialized then
      desktop.Render()
