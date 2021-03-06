module Index

open Elmish
open Elmish.React
open Fable.Remoting.Client
open Shared
open Zanaptak.TypedCssClasses
open Feliz.Router
open Feliz
open Feliz.Bulma

type Icon =
    CssClasses<"https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css", Naming.PascalCase>

type BmClass = CssClasses<"https://cdn.jsdelivr.net/npm/bulma@0.9.3/css/bulma.min.css", Naming.PascalCase>


//[<RequireQualifiedAccess>]
//type Page =
//| Detail
//| Home


type State = { CurrentUrl: string list }

type Msg = UrlChanged of string list


let init () = { CurrentUrl = Router.currentUrl () }


let update (msg: Msg) (state: State) : State =
    match msg with
    | UrlChanged url -> { state with CurrentUrl = url }


let NavbarBrand =
    Bulma.navbarItem.a [
        prop.href (Router.format "detail")
        prop.children [
            Html.img [
                prop.src "https://food.grab.com/static/images/logo-grabfood.svg"
                prop.height 28
                prop.width 112
            ]
        ]


    ]
let navBar =
    Bulma.navbar [
        Bulma.color.hasBackgroundWhite
        prop.children [
            Bulma.container [
                prop.children [
                    Bulma.navbarBrand.div [ NavbarBrand ]
                    Bulma.navbarMenu [
                        Bulma.navbarEnd.div [
                            Bulma.navbarItem.div [
                                Bulma.control.p [
                                    Bulma.button.button [
                                        Bulma.button.isSmall
                                        prop.children [
                                            Bulma.icon [
                                                Html.i [
                                                    prop.className "fas fa-shopping-bag fa-xs"
                                                ]
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                            Bulma.navbarItem.div [
                                Bulma.button.button [
                                    Bulma.button.isSmall
                                    prop.text "????ng nh???p"
                                ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]

let searchContainer =
    Bulma.container [
        Bulma.columns [
            Bulma.column [
                Bulma.text.hasTextLeft
                column.is3
                prop.style [
                    style.backgroundColor "#fff"
                ]
                prop.children [
                    Bulma.subtitle [
                        prop.text "Good morning"
                    ]

                    Bulma.title [
                        title.is2
                        prop.text "Let's explore good food near you."

                    ]
                    Bulma.block [
                        Bulma.control.p [
                            Bulma.control.hasIconsLeft
                            prop.children [
                                Bulma.input.text [
                                    prop.required true
                                    prop.placeholder "Nh???p ?????a ch??? c???a b???n"
                                ]
                                Bulma.icon [
                                    prop.className "has-text-danger"
                                    Bulma.icon.isSmall
                                    Bulma.icon.isLeft
                                    prop.children [
                                        Html.i [
                                            prop.className "fas fa-location-arrow"
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                    Bulma.block [
                        Bulma.button.button [
                            Bulma.button.isFullWidth
                            Bulma.color.isSuccess
                            prop.text "T??m Ki???m"
                        ]
                    ]

                ]

            ]

        ]

    ]

let viewHero =
    Bulma.block [
        Bulma.hero [
            Bulma.hero.isFullHeight
            prop.style [
                style.backgroundSize "cover"
                style.backgroundImageUrl "https://food.grab.com/static/page-home/VN-new-1.jpg"
                style.backgroundPosition "no-repeat center 50%"
            ]
            prop.children [
                Bulma.heroHead navBar
                Bulma.heroBody searchContainer
            ]
        ]
    ]

let viewItem =
    Bulma.column [
        Bulma.image [
            Bulma.image.is3by2
            image.isFullWidth
            prop.children [
                Html.img [
                    prop.src
                        "https://d1sag4ddilekf6.cloudfront.net/compressed/merchants/VNGFVN000004wq/hero/e69b5c6fb8674bd4a7d52fc04066d7f6_1626068038837955215.png"
                ]
            ]
        ]
        Bulma.title.h2 [
            title.is5
            prop.text "X??i C?? Thanh- Ng?? V??n Ch????ng"
        ]
        Bulma.title.h2 [
            title.is6
            text.hasTextWeightNormal
            color.hasTextGrey
            prop.text "B??nh m?? - X??i - B??nh M???n"
        ]
        Bulma.level [
            prop.children [
                Bulma.levelLeft [
                    prop.children [
                        Bulma.levelItem [
                            Bulma.icon [
                                prop.className "has-text-warning"
                                prop.children [
                                    Html.i [ prop.className "fas fa-star" ]
                                ]
                            ]
                            Html.span [ prop.text "4.7" ]
                        ]
                    ]

                ]
                Bulma.levelItem [
                    prop.children [
                        Bulma.icon [
                            Html.i [ prop.className "far fa-clock" ]
                        ]
                        Html.span [ prop.text "19 ph??t" ]
                    ]

                ]
                Bulma.levelRight [
                    prop.children [
                        Bulma.levelItem [
                            Bulma.icon [
                                prop.className "has-text-success"
                                prop.children [
                                    Html.i [ prop.className "fas fa-tag" ]
                                ]
                            ]
                            Html.span [ prop.text "1,3 km" ]
                        ]
                    ]

                ]

            ]

        ]
        Html.div [
            Html.span [
                prop.children [
                    Bulma.icon [
                        icon.isLeft
                        color.hasTextSuccess
                        prop.children [
                            Html.i [ prop.className "fas fa-tag" ]
                        ]
                    ]
                    Html.span [
                        prop.text "Gi???m 20% khi ?????t t???i thi???u 200.000???"
                    ]
                ]
            ]
        ]

    ]

let carousel =
    Bulma.block [
        Bulma.container [
            Bulma.title [
                title.is2
                prop.text "M?? khuy???n m??i GrabFood ??? H?? N???i"
            ]
            Bulma.columns [
                for x in [ 1 .. 4 ] do
                    viewItem
            ]
            Bulma.block [
                Bulma.button.button [
                    button.isFullWidth
                    button.isMedium
                    prop.children [
                        Bulma.title [
                            title.is5
                            prop.text "See all Promotions"
                        ]
                    ]
                ]
            ]
        ]
    ]

let foodContent =
    Bulma.column [
        column.is3
        prop.children [
            Bulma.image [
                Bulma.image.is3by2
                image.isFullWidth
                prop.children [
                    Html.img [
                        prop.src
                            "https://d1sag4ddilekf6.cloudfront.net/cuisine/29/icons/BubbleTea_be0ee7214fa04e99b8e1d5200c3cddd4_1547819077602874642.jpg"
                    ]
                ]
            ]
            Bulma.title.h2 [
                title.is5
                prop.text "Tr?? S???a"
            ]
        ]
    ]


let foodContainer =
    Bulma.block [
        Bulma.container [
            Bulma.title [
                title.is2
                prop.text "There's something for everyone!"
            ]
            Bulma.columns [
                columns.isMultiline
                prop.children [
                    for x in [ 1 .. 16 ] do
                        foodContent
                ]
            ]
        ]
    ]

let questionItem =
    Html.ul [
        Bulma.block [
            Html.li [
                Html.span [
                    Bulma.icon [
                        color.hasTextSuccess
                        prop.children [
                            Html.i [
                                prop.className [ Icon.Fa; Icon.FaCheck ]
                            ]
                        ]
                    ]
                    Html.span [
                        prop.className "has-text-weight-bold"
                        prop.text "Nhanh Nh???t"
                    ]
                    Html.span " - GrabFood cung c???p d???ch v??? giao ????? ??n nhanh nh???t th??? tr?????ng."
                ]
            ]
        ]

        Bulma.block [
            Html.li [
                Html.span [
                    Bulma.icon [
                        color.hasTextSuccess
                        prop.children [
                            Html.i [
                                prop.className [ Icon.Fa; Icon.FaCheck ]
                            ]
                        ]
                    ]
                    Html.span [
                        prop.className "has-text-weight-bold"
                        prop.text "D??? d??ng nh???t"
                    ]
                    Html.span
                        " - Gi??? ????y, b???n ch??? c???n th???c hi???n v??i c?? nh???p chu???t ho???c ch???m nh??? l?? ???? c?? th??? ?????t ????? ??n. H??y ?????t ????? ??n tr???c tuy???n ho???c t???i xu???ng si??u ???ng d???ng Grab c???a ch??ng t??i ????? c?? tr???i nghi???m nhanh h??n v?? th?? v??? h??n."
                ]
            ]
        ]

        Bulma.block [
            Html.li [
                Html.span [
                    Bulma.icon [
                        color.hasTextSuccess
                        prop.children [
                            Html.i [
                                prop.className [ Icon.Fa; Icon.FaCheck ]
                            ]
                        ]
                    ]
                    Html.span [
                        prop.className "has-text-weight-bold"
                        prop.text "????p ???ng m???i nhu c???u"
                    ]
                    Html.span
                        " - T??? m??n ??n ?????c s???n ?????a ph????ng ?????n c??c nh?? h??ng ???????c ??a th??ch, nhi???u l???a ch???n ??a d???ng ch???c ch???n s??? lu??n l??m h??i l??ng kh???u v??? c???a b???n."
                ]
            ]
        ]

        Bulma.block [
            Html.li [
                Html.span [
                    Bulma.icon [
                        color.hasTextSuccess
                        prop.children [
                            Html.i [
                                prop.className [ Icon.Fa; Icon.FaCheck ]
                            ]
                        ]
                    ]
                    Html.span [
                        prop.className "has-text-weight-bold"
                        prop.text "Thanh to??n d??? d??ng"
                    ]
                    Html.span
                        " - Giao v?? nh???n ????? ??n th???t d??? d??ng. Thanh to??n b???ng GrabPay th???m ch?? c??n d??? d??ng h??n n???a."
                ]
            ]
        ]
        Bulma.block [
            Html.li [
                Html.span [
                    Bulma.icon [
                        color.hasTextSuccess
                        prop.children [
                            Html.i [
                                prop.className [ Icon.Fa; Icon.FaCheck ]
                            ]
                        ]
                    ]
                    Html.span [
                        prop.className "has-text-weight-bold"
                        prop.text "Nhi???u qu?? t???ng h??n"
                    ]
                    Html.span
                        " - T??ch ??i???m GrabRewards cho m???i ????n h??ng c???a b???n v?? s??? d???ng ??i???m th?????ng ????? ?????i l???y nhi???u ??u ????i h??n."
                ]
            ]
        ]
    ]


let question =
    Bulma.block [
        Bulma.container [
            Bulma.title [
                title.is2
                prop.text "T???i sao n??n l???a ch???n GrabFood?"
            ]
            Bulma.container [
                questionItem

            ]

        ]

    ]

let questionBottom =
    Bulma.block [
        Bulma.container [
            Bulma.title [
                title.is2
                prop.text "C??c c??u h???i th?????ng g???p"
            ]
            Bulma.title [
                title.is4
                prop.text "GrabFood L?? G???"
            ]
            Bulma.block [
                Html.h2
                    "Lunch, B??n C?? Ch???m G???c ??a - V?? Th???nh for Dinner! We are here to satisfy your hunger with a wide selection of merchant partners in Vietnam. GrabFood l?? d???ch v??? Giao ????? ??n nhanh nh???t t???i Vi???t Nam. Ch??ng t??i ???? s???p x???p t???t c??? c??c m??n ??n, nh?? h??ng v?? th???c ph???m y??u th??ch c???a b???n m???t c??ch h???p l?? ????? gi??p b???n t??m ???????c ????? ??n d??? d??ng v?? nhanh ch??ng nh???t c?? th???. T??m v?? ?????t m??n ??n y??u th??ch tr??n kh???p Vi???t Nam - ?????t ????? ??n tr???c tuy???n ch??? b???ng v??i thao t??c, t??? m??n Lifted Coffee & Brunch cho b???a s??ng, ?????n Maazi Indian ??? Nh?? H??ng ???n ????? cho b???a tr??a, ?????n B??n C?? Ch???m G???c ??a ??? V?? Th???nh cho b???a t???i! H??y ????? ch??ng t??i xua tan c??n ????i c???a b???n nh??? m???t lo???t ?????i t??c b??n ????? ??n ??? Vi???t Nam."
            ]
            Bulma.block [
                Bulma.button.button [
                    button.isFullWidth
                    button.isMedium
                    text.hasTextWeightBold
                    prop.text "Read More"
                ]
            ]
        ]
    ]



let Footer =
    Html.div [
        color.hasBackgroundWhiteTer
        prop.children [
            Bulma.container [
                Bulma.footer [
                    Bulma.section [
                        Bulma.columns [
                            columns.isCentered
                            prop.children [
                                Bulma.column [
                                    column.isTwoFifths
                                    text.hasTextCentered
                                    prop.children [
                                        Bulma.image [
                                            Bulma.image.is128x128
                                            text.hasTextCentered
                                            Bulma.helpers.isInlineBlock
                                            prop.children [
                                                Html.img [
                                                    prop.src
                                                        "https://food.grab.com/static/page-home/bottom-food-options.svg"
                                                ]
                                            ]
                                        ]
                                        Bulma.title [
                                            title.is5
                                            prop.text "Curated restaurants"
                                        ]
                                        Bulma.title [
                                            title.is6
                                            text.hasTextWeightNormal
                                            prop.text
                                                "From small bites to big meals, we won't limit your appetite. Go ahead and order all you want."
                                        ]
                                    ]
                                ]
                                Bulma.column [
                                    column.isTwoFifths
                                    text.hasTextCentered
                                    prop.children [
                                        Bulma.image [
                                            Bulma.image.is128x128
                                            text.hasTextCentered
                                            Bulma.helpers.isInlineBlock
                                            prop.children [
                                                Html.img [
                                                    prop.src
                                                        "https://food.grab.com/static/images/ilus-cool-features-app.svg"
                                                ]
                                            ]
                                        ]
                                        Bulma.title [
                                            title.is5
                                            prop.text "More cool features available on the app"
                                        ]
                                        Bulma.title [
                                            title.is6
                                            text.hasTextWeightNormal

                                            prop.text
                                                "Download Grab app to use other payment methods and enjoy seamless communication with your driver."
                                        ]
                                        Bulma.container [
                                            Bulma.columns [
                                                Bulma.helpers.isFlex
                                                prop.children [

                                                    Bulma.column [
                                                        Html.img [
                                                            prop.src
                                                                "https://food.grab.com/static/images/logo-appstore.svg"
                                                        ]

                                                    ]
                                                    Bulma.column [
                                                        Html.img [
                                                            prop.src
                                                                "https://food.grab.com/static/images/logo-playstore.svg"
                                                        ]
                                                    ]

                                                ]

                                            ]

                                        ]

                                    ]

                                ]

                            ]

                        ]

                    ]

                ]

            ]

        ]

    ]
let bottomFooter =
    Html.div [
        color.hasBackgroundSuccess
        prop.children [
            Bulma.container [
                Bulma.hero [
                    hero.isMedium
                    prop.children [
                        Bulma.block [
                            Bulma.heroHead [
                                Bulma.navbar [
                                    Bulma.container [
                                        prop.style [
                                            style.borderBottomWidth 1
                                            style.borderBottomStyle borderStyle.solid
                                            style.borderBottomColor color.white
                                            style.marginBottom 30
                                        ]
                                        prop.children [

                                            Bulma.navbarBrand.div [
                                                Bulma.navbarItem.a [
                                                    Html.img [
                                                        prop.src
                                                            "https://food.grab.com/static/images/logo-grabfood-white.svg"
                                                    ]
                                                ]
                                            ]
                                            Bulma.navbarEnd.div [
                                                Bulma.control.p [
                                                    Bulma.control.hasIconsLeft
                                                    spacing.mt3
                                                    prop.children [
                                                        Bulma.select [
                                                            select.isSmall
                                                            prop.children [
                                                                Html.option "Country"
                                                                Html.option "Select dropdown"
                                                                Html.option "With options"
                                                            ]

                                                        ]
                                                        Bulma.icon [
                                                            Bulma.icon.isSmall
                                                            Bulma.icon.isLeft
                                                            prop.children [
                                                                Html.i [ prop.className "fas fa-globe" ]
                                                            ]
                                                        ]

                                                    ]

                                                ]

                                            ]

                                        ]

                                    ]

                                ]

                            ]
                            Html.div [
                                    Bulma.container [
                                        prop.style [
                                            style.borderBottomWidth 1
                                            style.borderBottomStyle borderStyle.solid
                                            style.borderBottomColor color.white
                                            style.margin(30, 0)
                                        ]
                                        prop.children [
                                            Bulma.columns [
                                            spacing.mb5
                                            prop.children [
                                                Bulma.column [
                                                    Bulma.block [
                                                        Html.a [
                                                            prop.className
                                                                "is-size-6 has-text-white has-text-weight-semibold"
                                                            prop.text "V??? GrabFood"
                                                        ]
                                                    ]
                                                    Bulma.block [
                                                        Html.a [
                                                            prop.className
                                                                "is-size-6 has-text-white has-text-weight-semibold"
                                                            prop.text "V??? Grab"
                                                        ]
                                                    ]
                                                    Bulma.block [
                                                        Html.a [
                                                            prop.className
                                                                "is-size-6 has-text-white has-text-weight-semibold"
                                                            prop.text "Blog"
                                                        ]
                                                    ]

                                                ]
                                                Bulma.column [
                                                    Bulma.block [
                                                        Html.a [
                                                            prop.className
                                                                "is-size-6 has-text-white has-text-weight-semibold"
                                                            prop.text "V??? GrabFood"
                                                        ]
                                                    ]
                                                    Bulma.block [
                                                        Html.a [
                                                            prop.className
                                                                "is-size-6 has-text-white has-text-weight-semibold"
                                                            prop.text "V??? Grab"
                                                        ]
                                                    ]
                                                    Bulma.block [
                                                        Html.a [
                                                            prop.className
                                                                "is-size-6 has-text-white has-text-weight-semibold"
                                                            prop.text "Blog"
                                                        ]
                                                    ]

                                                ]
                                                Bulma.column [
                                                    Bulma.block [
                                                        Html.a [
                                                            prop.className
                                                                "is-size-6 has-text-white has-text-weight-semibold"
                                                            prop.text "V??? GrabFood"
                                                        ]
                                                    ]
                                                    Bulma.block [
                                                        Html.a [
                                                            prop.className
                                                                "is-size-6 has-text-white has-text-weight-semibold"
                                                            prop.text "V??? Grab"
                                                        ]
                                                    ]
                                                    Bulma.block [
                                                        Html.a [
                                                            prop.className
                                                                "is-size-6 has-text-white has-text-weight-semibold"
                                                            prop.text "Blog"
                                                        ]
                                                    ]

                                                ]
                                                Bulma.column [
                                                    Bulma.helpers.isFlex
                                                    prop.children [
                                                        Html.span [
                                                            prop.className "icon-text is-large"
                                                            prop.children [
                                                                Bulma.icon [
                                                                    spacing.mr5
                                                                    color.hasTextWhite
                                                                    prop.children [
                                                                        Html.i [
                                                                            prop.className "fab fa-instagram"
                                                                            prop.style [ style.fontSize 30 ]
                                                                        ]
                                                                    ]
                                                                ]
                                                                Bulma.icon [
                                                                    spacing.mr5
                                                                    color.hasTextWhite
                                                                    prop.children [
                                                                        Html.i [
                                                                            prop.className "fab fa-facebook-square"
                                                                            prop.style [ style.fontSize 30 ]
                                                                        ]
                                                                    ]
                                                                ]
                                                                Bulma.icon [
                                                                    spacing.mr5
                                                                    color.hasTextWhite
                                                                    prop.children [
                                                                        Html.i [
                                                                            prop.className "fab fa-twitter-square"
                                                                            prop.style [ style.fontSize 30 ]
                                                                        ]
                                                                    ]
                                                                ]
                                                            ]

                                                        ]

                                                    ]

                                                ]
                                            ]

                                            ]

                                        ]

                                    ]
                            ]

                        ]

                    ]

                ]

            ]

        ]

    ]


let viewHome (state: State) (dispatch: Msg -> unit) =
    Html.div [
        viewHero
        carousel
        foodContainer
        question
        questionBottom
        Footer
        bottomFooter
    ]

let render (state: State) (dispatch: Msg -> unit) =
    let activePage =
        match state.CurrentUrl with
        | [] -> viewHome state dispatch
        | [ "detail" ] -> Detail.view
        | _ -> Html.h1 "Not Found"

    React.router [
        router.onUrlChanged (UrlChanged >> dispatch)
        router.children [ activePage ]


    ]

Program.mkSimple init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run
