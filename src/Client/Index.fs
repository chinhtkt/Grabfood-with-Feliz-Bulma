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
                                    prop.text "Đăng nhập"
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
                                    prop.placeholder "Nhập địa chỉ của bạn"
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
                            prop.text "Tìm Kiếm"
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
            prop.text "Xôi Cô Thanh- Ngõ Văn Chương"
        ]
        Bulma.title.h2 [
            title.is6
            text.hasTextWeightNormal
            color.hasTextGrey
            prop.text "Bánh mì - Xôi - Bánh Mặn"
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
                        Html.span [ prop.text "19 phút" ]
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
                        prop.text "Giảm 20% khi đặt tối thiểu 200.000₫"
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
                prop.text "Mã khuyến mãi GrabFood ở Hà Nội"
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
                prop.text "Trà Sữa"
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
                        prop.text "Nhanh Nhất"
                    ]
                    Html.span " - GrabFood cung cấp dịch vụ giao đồ ăn nhanh nhất thị trường."
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
                        prop.text "Dễ dàng nhất"
                    ]
                    Html.span
                        " - Giờ đây, bạn chỉ cần thực hiện vài cú nhấp chuột hoặc chạm nhẹ là đã có thể đặt đồ ăn. Hãy đặt đồ ăn trực tuyến hoặc tải xuống siêu ứng dụng Grab của chúng tôi để có trải nghiệm nhanh hơn và thú vị hơn."
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
                        prop.text "Đáp ứng mọi nhu cầu"
                    ]
                    Html.span
                        " - Từ món ăn đặc sản địa phương đến các nhà hàng được ưa thích, nhiều lựa chọn đa dạng chắc chắn sẽ luôn làm hài lòng khẩu vị của bạn."
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
                        prop.text "Thanh toán dễ dàng"
                    ]
                    Html.span
                        " - Giao và nhận đồ ăn thật dễ dàng. Thanh toán bằng GrabPay thậm chí còn dễ dàng hơn nữa."
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
                        prop.text "Nhiều quà tặng hơn"
                    ]
                    Html.span
                        " - Tích điểm GrabRewards cho mỗi đơn hàng của bạn và sử dụng điểm thưởng để đổi lấy nhiều ưu đãi hơn."
                ]
            ]
        ]
    ]


let question =
    Bulma.block [
        Bulma.container [
            Bulma.title [
                title.is2
                prop.text "Tại sao nên lựa chọn GrabFood?"
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
                prop.text "Các câu hỏi thường gặp"
            ]
            Bulma.title [
                title.is4
                prop.text "GrabFood Là Gì?"
            ]
            Bulma.block [
                Html.h2
                    "Lunch, Bún Cá Chấm Gốc Đa - Vũ Thạnh for Dinner! We are here to satisfy your hunger with a wide selection of merchant partners in Vietnam. GrabFood là dịch vụ Giao đồ ăn nhanh nhất tại Việt Nam. Chúng tôi đã sắp xếp tất cả các món ăn, nhà hàng và thực phẩm yêu thích của bạn một cách hợp lý để giúp bạn tìm được đồ ăn dễ dàng và nhanh chóng nhất có thể. Tìm và đặt món ăn yêu thích trên khắp Việt Nam - đặt đồ ăn trực tuyến chỉ bằng vài thao tác, từ món Lifted Coffee & Brunch cho bữa sáng, đến Maazi Indian – Nhà Hàng Ấn Độ cho bữa trưa, đến Bún Cá Chấm Gốc Đa – Vũ Thạnh cho bữa tối! Hãy để chúng tôi xua tan cơn đói của bạn nhờ một loạt đối tác bán đồ ăn ở Việt Nam."
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
                                                            prop.text "Về GrabFood"
                                                        ]
                                                    ]
                                                    Bulma.block [
                                                        Html.a [
                                                            prop.className
                                                                "is-size-6 has-text-white has-text-weight-semibold"
                                                            prop.text "Về Grab"
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
                                                            prop.text "Về GrabFood"
                                                        ]
                                                    ]
                                                    Bulma.block [
                                                        Html.a [
                                                            prop.className
                                                                "is-size-6 has-text-white has-text-weight-semibold"
                                                            prop.text "Về Grab"
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
                                                            prop.text "Về GrabFood"
                                                        ]
                                                    ]
                                                    Bulma.block [
                                                        Html.a [
                                                            prop.className
                                                                "is-size-6 has-text-white has-text-weight-semibold"
                                                            prop.text "Về Grab"
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
