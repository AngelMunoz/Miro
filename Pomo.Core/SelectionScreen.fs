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

      // Helper function to create buttons
      let createButton text onClick =
        let button = new Button()
        button.Content <- new Label(Text = text)
        button.Width <- 200
        button.Height <- 50
        button.Click.Add(onClick)
        button

      // Create menu buttons
      let newGameButton = createButton "New Game" (fun _ -> 
        System.Console.WriteLine("New Game clicked")
      )
      
      let loadGameButton = createButton "Load Game" (fun _ -> 
        System.Console.WriteLine("Load Game clicked")
      )
      
      let settingsButton = createButton "Settings" (fun _ -> 
        System.Console.WriteLine("Settings clicked")
      )
      
      let exitButton = createButton "Exit" (fun _ -> 
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
