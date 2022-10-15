using System;
using System.Collections;
using System.Collections.Generic;

namespace CsharpExam
{
    /*
     * 【参考文章】
     *  - https://blog.csdn.net/byondocean/article/details/6871881
     *  - https://blog.csdn.net/qq_51533157/article/details/125939000?spm=1001.2101.3001.6661.1&utm_medium=distribute.pc_relevant_t0.none-task-blog-2%7Edefault%7ECTRLIST%7ERate-1-125939000-blog-77824940.pc_relevant_multi_platform_whitelistv3&depth_1-utm_source=distribute.pc_relevant_t0.none-task-blog-2%7Edefault%7ECTRLIST%7ERate-1-125939000-blog-77824940.pc_relevant_multi_platform_whitelistv3&utm_relevant_index=1
     */

    /// <summary>
    /// 迭代器的实现
    /// </summary>
    public class _20221015_IEnumerable
    {
        public static void Main(string[] args)
        {
            PhotoAlbum MyPhotoAlbum = new PhotoAlbum(
                new Photo(1, "A"),
                new Photo(2, "B"),
                new Photo(3, "C"));

            foreach (Photo photo in MyPhotoAlbum)
                Console.WriteLine($"foreach.1: photo=[ID={photo.ID}, Note={photo.Note}]");

            IEnumerator<Photo> myPhotoAlbumEnumerator = MyPhotoAlbum.GetPhotoAlbumEnumerator();
            while (myPhotoAlbumEnumerator.MoveNext())
                Console.WriteLine($"foreach.2: photo=[ID={myPhotoAlbumEnumerator.Current.ID}, Note={myPhotoAlbumEnumerator.Current.Note}]");
        }

        private class PhotoAlbum : IEnumerable<Photo>
        {
            private Photo[] m_Photos;

            public PhotoAlbum(params Photo[] photos)
            {
                int count = photos.Length;
                m_Photos = new Photo[count];

                for (int i = 0; i < count; i++)
                    m_Photos[i] = photos[i];
            }

            //yield return语法糖 创建返回迭代器
            public IEnumerator<Photo> GetEnumerator()
            {
                for (int i = 0; i < m_Photos.Length; i++)
                    yield return m_Photos[i];
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            //自行实现/创建返回迭代器
            public IEnumerator<Photo> GetPhotoAlbumEnumerator()
            {
                return new PhotoAlbumEnumerator(m_Photos);
            }
        }

        private class Photo
        {
            public int ID { get; private set; }
            public string Note { get; private set; }

            public Photo(int id, string note)
            {
                ID = id;
                Note = note;
            }
        }

        private class PhotoAlbumEnumerator : IEnumerator<Photo>
        {
            private Photo[] m_Photos;
            private int index;

            public PhotoAlbumEnumerator(Photo[] photos)
            {
                m_Photos = photos;
                index = -1;
            }

            public bool MoveNext()
            {
                index++;
                return index < m_Photos.Length;
            }

            public void Reset()
            {
                index = -1;
            }

            public Photo Current
            {
                get { return m_Photos[index]; }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}