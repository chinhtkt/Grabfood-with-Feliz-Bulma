module Detail

open Elmish
open Fable.Remoting.Client
open Shared
open Zanaptak.TypedCssClasses

type Model = { Todos: Todo list; Input: string }

type Icon =
    CssClasses<"https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css", Naming.PascalCase>

type BmClass = CssClasses<"https://cdn.jsdelivr.net/npm/bulma@0.9.3/css/bulma.min.css", Naming.PascalCase>


open Feliz
open Feliz.Bulma

let navbar =
    Bulma.block [
        Html.header [
            Bulma.container [
                Bulma.navbar [
                    Bulma.navbarBrand.div [
                        Bulma.navbarItem.a [
                            Html.img [
                                prop.src "https://food.grab.com/static/images/logo-grabfood.svg"
                            ]
                        ]
                    ]
                    Bulma.navbarStart.div [
                        Bulma.navbarItem.div [
                            Bulma.control.p [
                                Bulma.control.hasIconsLeft
                                prop.children [
                                    Bulma.input.text [
                                        prop.required true
                                        prop.placeholder "Nhập địa chỉ của bạn"
                                    ]
                                    Bulma.icon [
                                        Bulma.icon.isSmall
                                        Bulma.icon.isLeft
                                        prop.className "has-text-danger"
                                        prop.children [
                                            Html.i [
                                                prop.className "fas fa-location-arrow"
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                    Bulma.navbarMenu [
                        Bulma.navbarEnd.div [
                            Bulma.navbarItem.div [
                                Bulma.control.p [
                                    Bulma.button.button [
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
                                    prop.text "Đăng nhập"
                                ]
                            ]
                        ]
                    ]

                ]

            ]

        ]

    ]

let carouselItem =
    Bulma.column [
        prop.children [
            Html.img [
                prop.src
                    "https://d1sag4ddilekf6.cloudfront.net/collections/77/icons/upload-photo-icon_3a03d381803848f4b37cdef84f0a0c2d_1552882932662284115.jpeg"
            ]
        ]
    ]

let carousel =
    Html.div [
        Bulma.block [
            Bulma.container [
                Bulma.control.p [
                    Bulma.control.hasIconsLeft
                    prop.children [
                        Bulma.input.text [
                            prop.required true
                            prop.placeholder "Tìm món hoặc quán ăn"
                            color.hasBackgroundWhiteTer
                        ]
                        Bulma.icon [
                            Bulma.icon.isSmall
                            Bulma.icon.isLeft
                            prop.children [
                                Html.i [
                                    prop.className "fas fa-search"
                                ]
                            ]
                        ]
                    ]

                ]

            ]

        ]
        Bulma.block [
            Bulma.container [
                Bulma.columns [
                    Bulma.helpers.isFlex
                    prop.children [
                        for x in [ 1 .. 6 ] do
                            carouselItem
                    ]
                ]
            ]
        ]
        Bulma.block [
            Html.div [
                prop.className "has-background-gray"
                prop.style [
                    style.height 10
                    style.backgroundColor "#f7f7f7"
                ]
            ]
        ]

    ]

let carouselFoodSectionItem =
    Bulma.column [
        Bulma.image [
            Bulma.image.is3by2
            image.isFullWidth
            prop.children [
                Html.img [
                    prop.src
                        "https://d1sag4ddilekf6.azureedge.net/Merchants/VNGFVN000003g9/photos/132bfd7f88c5463887419f231f1515a1_1559710946055833150.jpeg"
                ]
            ]
        ]
        Bulma.title.h2 [
            title.is5
            prop.text "Bánh Mì Giò Chả Dũng Hạnh - Lê Đại Hành"
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

let carouselFoodSection =
    Bulma.block [
        Html.div [
            Bulma.block [
                Bulma.container [
                    Bulma.breadcrumb [
                        breadcrumb.hasSucceedsSeparator
                        breadcrumb.isMedium
                        prop.children [
                            Html.ul [
                                Html.li [
                                    Html.a [ prop.text "Trang chủ" ]
                                ]
                                Html.li [
                                    prop.className "is-active"
                                    prop.children [
                                        Html.a [ prop.text "Nhà Hàng" ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                    Bulma.title "Món ngon gần bạn"
                ]

            ]
            Bulma.block [
                Bulma.container [
                    Bulma.columns [
                        Bulma.helpers.isFlex
                        prop.children [
                            for x in [ 1 .. 4 ] do
                                carouselFoodSectionItem
                        ]
                    ]
                ]
            ]

        ]

    ]

let FoodSectionItem =
    Bulma.column [
        column.is3
        prop.children [
            Bulma.image [
                Bulma.image.is3by2
                image.isFullWidth
                prop.children [
                    Html.img [
                        prop.src
                            "https://d1sag4ddilekf6.azureedge.net/compressed/merchants/5-C2VGABU1AEUCDE/hero/fa1817aeb80647da93aadfc96ead49c1_1625436000568384137.png"
                    ]
                ]

            ]
            Bulma.title.h2 [
                title.is5
                prop.text "Bánh Mì Giò Chả Dũng Hạnh - Lê Đại Hành"
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

        ]

    ]

let FoodSection =
    Bulma.block [
    Html.div [
        Bulma.block [
            Bulma.container [
                Bulma.title "Các quán ăn tại Hà Nội"
                Bulma.columns [
                    columns.isMultiline
                    prop.children [
                        for x in [ 1 .. 16 ] do
                            FoodSectionItem
                    ]
                ]
                Bulma.block [
                    Bulma.button.button [
                        button.isFullWidth
                        button.isMedium
                        prop.text "Xem Thêm"
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


let view =
    Html.div [
        Html.section [
            navbar
            carousel
            carouselFoodSection
            FoodSection
            bottomFooter
        ]

    ]
