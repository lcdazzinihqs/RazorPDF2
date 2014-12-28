using System;

/*
 * Copyright 2002 by Josselin PUJO.
 *
 * The contents of this file are subject to the Mozilla Public License Version 1.1
 * (the "License"); you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS" basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the License.
 *
 * The Original Code is 'iText, a free JAVA-PDF library'.
 *
 * The Initial Developer of the Original Code is Bruno Lowagie. Portions created by
 * the Initial Developer are Copyright (C) 1999, 2000, 2001, 2002 by Bruno Lowagie.
 * All Rights Reserved.
 * Co-Developer of the code is Paulo Soares. Portions created by the Co-Developer
 * are Copyright (C) 2000, 2001, 2002 by Paulo Soares. All Rights Reserved.
 *
 * Contributor(s): all the names of the contributors are added in the source code
 * where applicable.
 *
 * Alternatively, the contents of this file may be used under the terms of the
 * LGPL license (the "GNU LIBRARY GENERAL PUBLIC LICENSE"), in which case the
 * provisions of LGPL are applicable instead of those above.  If you wish to
 * allow use of your version of this file only under the terms of the LGPL
 * License and not to allow others to use your version of this file under
 * the MPL, indicate your decision by deleting the provisions above and
 * replace them with the notice and other provisions required by the LGPL.
 * If you do not delete the provisions above, a recipient may use your version
 * of this file under either the MPL or the GNU LIBRARY GENERAL PUBLIC LICENSE.
 *
 * This library is free software; you can redistribute it and/or modify it
 * under the terms of the MPL as stated above or under the terms of the GNU
 * Library General Public License as published by the Free Software Foundation;
 * either version 2 of the License, or any later version.
 *
 * This library is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU Library general Public License for more
 * details.
 *
 * If you didn't download this code from the following link, you should check if
 * you aren't using an obsolete version:
 * http://www.lowagie.com/iText/
 */

namespace RazorPDF.Legacy.Text.Pdf {

    public class PdfTransition {
        /**
         *  Out Vertical Split
         */
        public const int SPLITVOUT      = 1;
        /**
         *  Out Horizontal Split
         */
        public const int SPLITHOUT      = 2;
        /**
         *  In Vertical Split
         */
        public const int SPLITVIN      = 3;
        /**
         *  IN Horizontal Split
         */
        public const int SPLITHIN      = 4;
        /**
         *  Vertical Blinds
         */
        public const int BLINDV      = 5;
        /**
         *  Vertical Blinds
         */
        public const int BLINDH      = 6;
        /**
         *  Inward Box
         */
        public const int INBOX       = 7;
        /**
         *  Outward Box
         */
        public const int OUTBOX      = 8;
        /**
         *  Left-Right Wipe
         */
        public const int LRWIPE      = 9;
        /**
         *  Right-Left Wipe
         */
        public const int RLWIPE     = 10;
        /**
         *  Bottom-Top Wipe
         */
        public const int BTWIPE     = 11;
        /**
         *  Top-Bottom Wipe
         */
        public const int TBWIPE     = 12;
        /**
         *  Dissolve
         */
        public const int DISSOLVE    = 13;
        /**
         *  Left-Right Glitter
         */
        public const int LRGLITTER   = 14;
        /**
         *  Top-Bottom Glitter
         */
        public const int TBGLITTER  = 15;
        /**
         *  Diagonal Glitter
         */
        public const int DGLITTER  = 16;
    
        /**
         *  duration of the transition effect
         */
        protected int duration;
        /**
         *  type of the transition effect
         */
        protected int type;
    
        /**
         *  Constructs a <CODE>Transition</CODE>.
         *
         */
        public PdfTransition() : this(BLINDH) {}
    
        /**
         *  Constructs a <CODE>Transition</CODE>.
         *
         *@param  type      type of the transition effect
         */
        public PdfTransition(int type) : this(type,1) {}
    
        /**
         *  Constructs a <CODE>Transition</CODE>.
         *
         *@param  type      type of the transition effect
         *@param  duration  duration of the transition effect
         */
        public PdfTransition(int type, int duration) {
            this.duration = duration;
            this.type = type;
        }
    
    
        public int Duration {
            get {
                return duration;
            }
        }
    
    
        public int Type {
            get {
                return type;
            }
        }

        public PdfDictionary TransitionDictionary {
            get {
                PdfDictionary trans = new PdfDictionary(PdfName.TRANS);
                switch (type) {
                    case SPLITVOUT:
                        trans.Put(PdfName.S,PdfName.SPLIT);
                        trans.Put(PdfName.D,new PdfNumber(duration));
                        trans.Put(PdfName.DM,PdfName.V);
                        trans.Put(PdfName.M,PdfName.O);
                        break;
                    case SPLITHOUT:
                        trans.Put(PdfName.S,PdfName.SPLIT);
                        trans.Put(PdfName.D,new PdfNumber(duration));
                        trans.Put(PdfName.DM,PdfName.H);
                        trans.Put(PdfName.M,PdfName.O);
                        break;
                    case SPLITVIN:
                        trans.Put(PdfName.S,PdfName.SPLIT);
                        trans.Put(PdfName.D,new PdfNumber(duration));
                        trans.Put(PdfName.DM,PdfName.V);
                        trans.Put(PdfName.M,PdfName.I);
                        break;
                    case SPLITHIN:
                        trans.Put(PdfName.S,PdfName.SPLIT);
                        trans.Put(PdfName.D,new PdfNumber(duration));
                        trans.Put(PdfName.DM,PdfName.H);
                        trans.Put(PdfName.M,PdfName.I);
                        break;
                    case BLINDV:
                        trans.Put(PdfName.S,PdfName.BLINDS);
                        trans.Put(PdfName.D,new PdfNumber(duration));
                        trans.Put(PdfName.DM,PdfName.V);
                        break;
                    case BLINDH:
                        trans.Put(PdfName.S,PdfName.BLINDS);
                        trans.Put(PdfName.D,new PdfNumber(duration));
                        trans.Put(PdfName.DM,PdfName.H);
                        break;
                    case INBOX:
                        trans.Put(PdfName.S,PdfName.BOX);
                        trans.Put(PdfName.D,new PdfNumber(duration));
                        trans.Put(PdfName.M,PdfName.I);
                        break;
                    case OUTBOX:
                        trans.Put(PdfName.S,PdfName.BOX);
                        trans.Put(PdfName.D,new PdfNumber(duration));
                        trans.Put(PdfName.M,PdfName.O);
                        break;
                    case LRWIPE:
                        trans.Put(PdfName.S,PdfName.WIPE);
                        trans.Put(PdfName.D,new PdfNumber(duration));
                        trans.Put(PdfName.DI,new PdfNumber(0));
                        break;
                    case RLWIPE:
                        trans.Put(PdfName.S,PdfName.WIPE);
                        trans.Put(PdfName.D,new PdfNumber(duration));
                        trans.Put(PdfName.DI,new PdfNumber(180));
                        break;
                    case BTWIPE:
                        trans.Put(PdfName.S,PdfName.WIPE);
                        trans.Put(PdfName.D,new PdfNumber(duration));
                        trans.Put(PdfName.DI,new PdfNumber(90));
                        break;
                    case TBWIPE:
                        trans.Put(PdfName.S,PdfName.WIPE);
                        trans.Put(PdfName.D,new PdfNumber(duration));
                        trans.Put(PdfName.DI,new PdfNumber(270));
                        break;
                    case DISSOLVE:
                        trans.Put(PdfName.S,PdfName.DISSOLVE);
                        trans.Put(PdfName.D,new PdfNumber(duration));
                        break;
                    case LRGLITTER:
                        trans.Put(PdfName.S,PdfName.GLITTER);
                        trans.Put(PdfName.D,new PdfNumber(duration));
                        trans.Put(PdfName.DI,new PdfNumber(0));
                        break;
                    case TBGLITTER:
                        trans.Put(PdfName.S,PdfName.GLITTER);
                        trans.Put(PdfName.D,new PdfNumber(duration));
                        trans.Put(PdfName.DI,new PdfNumber(270));
                        break;
                    case DGLITTER:
                        trans.Put(PdfName.S,PdfName.GLITTER);
                        trans.Put(PdfName.D,new PdfNumber(duration));
                        trans.Put(PdfName.DI,new PdfNumber(315));
                        break;
                }
                return trans;
            }
        }
    }
}