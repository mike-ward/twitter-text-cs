﻿using System;
using System.Text.RegularExpressions;

namespace Twitter.Text {

    /// <summary>
    /// 
    /// </summary>
    public class TweetEntity {

         /// <summary>
        /// 
        /// </summary>
        public int Start { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public int End { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public string Value { get; internal set; }

        /// <summary>
        /// listSlug is used to store the list portion of @mention/list.
        /// </summary>
        public string ListSlug { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public TweetEntityType Type { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public string DisplayUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ExpandedUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="value"></param>
        /// <param name="listSlug"></param>
        /// <param name="type"></param>
        public TweetEntity(int start, int end, string value, string listSlug, TweetEntityType type) {
            this.Start = start;
            this.End = end;
            this.Value = value;
            this.ListSlug = listSlug;
            this.Type = type;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        public TweetEntity(int start, int end, string value, TweetEntityType type)
            : this(start, end, value, null, type) {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matcher"></param>
        /// <param name="type"></param>
        /// <param name="groupNumber"></param>
        public TweetEntity(Match matcher, TweetEntityType type, int groupNumber)
            : this(matcher, type, groupNumber, -1) // Offset -1 on start index to include @, # symbols for mentions and hashtags
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matcher"></param>
        /// <param name="type"></param>
        /// <param name="groupNumber"></param>
        /// <param name="startOffset"></param>
        public TweetEntity(Match matcher, TweetEntityType type, int groupNumber, int startOffset)
            : this(matcher.Groups[groupNumber].Index + startOffset, matcher.Groups[groupNumber].Index + matcher.Groups[groupNumber].Length, matcher.Groups[groupNumber].Value, type) {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj) {
            if (this == obj) {
                return true;
            }

            if (!(obj is TweetEntity)) {
                return false;
            }

            TweetEntity other = (TweetEntity)obj;

            if (Type.Equals(other.Type) &&
                Start == other.Start &&
                End == other.End &&
                Value.Equals(other.Value)) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() {
            return Type.GetHashCode() + Value.GetHashCode() + Start + End;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("{0}({1})[{2},{3}]", Value, Type, Start, End);
        }
    }
}