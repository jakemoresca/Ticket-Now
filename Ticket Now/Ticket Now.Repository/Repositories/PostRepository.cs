using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog_vNext.Repositories
{
    public class PostRepository : IPostRepository
    {
        //private readonly IStandardDao<PostDto> _postDao;

        //public PostRepository(IStandardDao<PostDto> postDao)
        //{
        //    _postDao = postDao;
        //}

        //public PostDto Create(PostDto entity)
        //{
        //    entity.Id = Guid.NewGuid();
        //    var updatedEntity = _postDao.Save(entity);
        //    return updatedEntity;
        //}

        //public PostDto Update(PostDto entity)
        //{
        //    entity.Id = Guid.NewGuid();
        //    var newVersionPost = IncrementVersion(entity);
        //    var updatedEntity = _postDao.Save(newVersionPost);
        //    return updatedEntity;
        //}

        //public int Delete(Guid id)
        //{
        //    return _postDao.Delete(id);
        //}

        //public PostDto FindById(Guid id)
        //{
        //    return _postDao.LoadAll().FirstOrDefault(p => p.Id == id);
        //}

        //public IList<PostDto> SearchPost(string criteria)
        //{
        //    return _postDao.LoadAll().Where(p => p.Title == criteria || p.Content == criteria).ToList();
        //}

        //public IList<PostDto> GetAll()
        //{
        //    return _postDao.LoadAll();
        //}

        //public IList<PostDto> GetAllLatest()
        //{
        //    var posts = _postDao.LoadAll().GroupBy(p => p.GroupId)
        //        .Select(p => p
        //            .OrderByDescending(x => x.MajorVersion)
        //            .ThenByDescending(y => y.MinorVersion)
        //            .FirstOrDefault()).ToList();

        //    return posts;
        //}

        //public IList<PostDto> FindByGroupId(Guid id)
        //{
        //    return _postDao.LoadAll().Where(p => p.GroupId == id).ToList();
        //}

        //private static PostDto IncrementVersion(PostDto postDto)
        //{
        //    var newVersionPost = postDto;
        //    var nextPostVersion = VersionHelper.GetNextVersion(new Version(postDto.MajorVersion, postDto.MinorVersion));
        //    newVersionPost.MajorVersion = nextPostVersion.Major;
        //    newVersionPost.MinorVersion = nextPostVersion.Minor;            

        //    return newVersionPost;
        //}
    }
}