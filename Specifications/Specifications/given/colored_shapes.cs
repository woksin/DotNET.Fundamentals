﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Machine.Specifications;

namespace Dolittle.Specifications.Specs.given
{
    public class colored_shapes
    {
        protected static IQueryable<ColoredShape> my_colored_shapes;
        protected static string[] colors;
        protected static string[] shapes;

        protected static ColoredShape red_square = new ColoredShape(){ Color = "Red", Shape = "Square"};
        protected static ColoredShape red_circle = new ColoredShape(){ Color = "Red", Shape = "Circle"};
        protected static ColoredShape green_circle = new ColoredShape(){ Color = "Green", Shape = "Circle"};
        protected static ColoredShape green_square = new ColoredShape(){ Color = "Green", Shape = "Square"};

        Establish context = () =>
            {
                colors = new string[] {"Red","Blue","Green","Yellow"};
                shapes = new string[]{"Square","Circle","Triangle","Pentagon"};

                my_colored_shapes = BuildColoredShapes();
            };

        static IQueryable<ColoredShape> BuildColoredShapes()
        {
           return (from color in colors
                    from shape in shapes
                    select new ColoredShape { Color = color, Shape = shape }).AsQueryable();
        }
    }
}