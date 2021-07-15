module Index

open Elmish
open Fable.Remoting.Client
open Shared

type Model = { Todos: Todo list; Input: string }

type Msg =
    | GotTodos of Todo list
    | SetInput of string
    | AddTodo
    | AddedTodo of Todo

let todosApi =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.buildProxy<ITodosApi>

let init () : Model * Cmd<Msg> =
    let model = { Todos = []; Input = "" }

    let cmd =
        Cmd.OfAsync.perform todosApi.getTodos () GotTodos

    model, cmd

let update (msg: Msg) (model: Model) : Model * Cmd<Msg> =
    match msg with
    | GotTodos todos -> { model with Todos = todos }, Cmd.none
    | SetInput value -> { model with Input = value }, Cmd.none
    | AddTodo ->
        let todo = Todo.create model.Input

        let cmd =
            Cmd.OfAsync.perform todosApi.addTodo todo AddedTodo

        { model with Input = "" }, cmd
    | AddedTodo todo ->
        { model with
              Todos = model.Todos @ [ todo ] },
        Cmd.none

open Feliz
open Feliz.Bulma

// let navBrand =
//     Bulma.navbarBrand.div [
//         Bulma.navbarItem.a [
//             prop.href "https://safe-stack.github.io/"
//             navbarItem.isActive
//             prop.children [
//                 Html.img [
//                     prop.src "/favicon.png"
//                     prop.alt "Logo"
//                 ]
//             ]
//         ]
//     ]

// let containerBox (model: Model) (dispatch: Msg -> unit) =
//     Bulma.box [
//         Bulma.content [
//             Html.ol [
//                 for todo in model.Todos do
//                     Html.li [ prop.text todo.Description ]
//             ]
//         ]
//         Bulma.field.div [
//             field.isGrouped
//             prop.children [
//                 Bulma.control.p [
//                     control.isExpanded
//                     prop.children [
//                         Bulma.input.text [
//                             prop.value model.Input
//                             prop.placeholder "What needs to be done?"
//                             prop.onChange (fun x -> SetInput x |> dispatch)
//                         ]
//                     ]
//                 ]
//                 Bulma.control.p [
//                     Bulma.button.a [
//                         color.isPrimary
//                         prop.disabled (Todo.isValid model.Input |> not)
//                         prop.onClick (fun _ -> dispatch AddTodo)
//                         prop.text "Add"
//                     ]
//                 ]
//             ]
//         ]
//     ]

let navBar =
    Bulma.navbar [
        Bulma.color.hasBackgroundWhite
        prop.children [
            Bulma.container [
                prop.children [
                    Bulma.navbarBrand.div [
                        Bulma.navbarItem.a [
                            Html.img [
                                prop.src "https://food.grab.com/static/images/logo-grabfood.svg"
                                prop.height 28
                                prop.width 112
                            ]
                        ]
                    ]
                    Bulma.navbarMenu [
                        Bulma.navbarEnd.div [
                            Bulma.navbarItem.div [
                                Bulma.control.p [
                                    Bulma.button.button [
                                        Bulma.icon [
                                            Html.i [
                                                prop.className "fas fa-shopping-bag fa-xs"
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                            Bulma.navbarItem.div [
                                Bulma.button.button [
                                    prop.text "Log in"
                                ]

                            ]

                        ]

                    ]

                ]

            ]

        ]

    ]

    
let view (model: Model) (dispatch: Msg -> unit) =
    Html.div [
        Bulma.hero [
            Bulma.hero.isFullHeight
            prop.style [
                style.backgroundSize "cover"
                style.backgroundImageUrl "https://food.grab.com/static/page-home/VN-new-1.jpg"
                style.backgroundPosition "no-repeat center 50%"
            ]
            prop.children [

                navBar

            ]

        ]

    ]
