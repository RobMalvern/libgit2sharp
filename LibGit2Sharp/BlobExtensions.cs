﻿using System;
using System.IO;
using System.Text;
using LibGit2Sharp.Core;

namespace LibGit2Sharp
{
    /// <summary>
    /// Provides helper overloads to a <see cref="Blob"/>.
    /// </summary>
    public static class BlobExtensions
    {
        /// <summary>
        /// Gets the blob content decoded with the specified encoding,
        /// or according to byte order marks, with UTF8 as fallback,
        /// if <paramref name="encoding"/> is null.
        /// </summary>
        /// <param name="blob">The blob for which the content will be returned.</param>
        /// <param name="encoding">The encoding of the text. (default: detected or UTF8)</param>
        /// <returns>Blob content as text.</returns>
        public static string ContentAsText(this Blob blob, Encoding encoding = null)
        {
            Ensure.ArgumentNotNull(blob, "blob");

            using (var reader = new StreamReader(blob.ContentStream, encoding ?? Encoding.UTF8, encoding == null))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Gets the blob content decoded as UTF-8.
        /// </summary>
        /// <param name="blob">The blob for which the content will be returned.</param>
        /// <returns>Blob content as UTF-8</returns>
        [Obsolete("This method will be removed in the next release. Please use ContentAsText()")]
        public static string ContentAsUtf8(this Blob blob)
        {
            Ensure.ArgumentNotNull(blob, "blob");

            return blob.ContentAsText(Encoding.UTF8);
        }

        /// <summary>
        /// Gets the blob content decoded as Unicode.
        /// </summary>
        /// <param name="blob">The blob for which the content will be returned.</param>
        /// <returns>Blob content as unicode.</returns>
        [Obsolete("This method will be removed in the next release. Please use ContentAsText()")]
        public static string ContentAsUnicode(this Blob blob)
        {
            Ensure.ArgumentNotNull(blob, "blob");

            return blob.ContentAsText(Encoding.Unicode);
        }
    }
}
