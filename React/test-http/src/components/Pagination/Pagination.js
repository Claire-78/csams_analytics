import React, { useState } from "react";
import ReactPaginate from "react-paginate";

export function Pagination  ({postsPerPage,totalPosts,paginate,posts,pagesVisited})  {
    console.log('HERE!!! ',{postsPerPage}, {totalPosts})
    const pageNumbers=[];
    const [pageNumber, setPageNumber] = useState(0);
    // for(let i=1;i<=Math.ceil(totalPosts/postsPerPage);i++){
    //     pageNumbers.push(i);
    // }
    // pageNumbers.push(1);
    // pageNumbers.push(Math.ceil(totalPosts/postsPerPage));
    const pageCount = Math.ceil(totalPosts/postsPerPage)

        const changePage=({selected})=> {
            setPageNumber(selected)
        };

        const displayposts = posts
        .slice(pagesVisited, pagesVisited + postsPerPage)
        .map((post) => {
          return (
            <li key={post.id} className='list-group-item' style={{border:'solid'}}>
            {post.id} | {post.userReviewer} | {post.assignment.description} 
        </li>
          );
        });
    




    return (
      <nav>
          <ul className='pagination'>
              {/* {pageNumbers.map(number=>(
                  <li key={number} className='page-item'>
                      <button onClick={()=>paginate(number)}  className='page-link'>
                          {number}
                      </button>
                  

                     
                    </li>

              ))} */}
              {displayposts}
                  <ReactPaginate 
                      previousLabel={"Previous"}
                      nextLabel={"Next"}
                      pageCount={pageCount}
                      onPageChange={changePage}
                      containerClassName={"paginationBttns"}
        previousLinkClassName={"previousBttn"}
        nextLinkClassName={"nextBttn"}
        disabledClassName={"paginationDisabled"}
        activeClassName={"paginationActive"}
                      
                      />
          </ul>
      </nav>
    )
}
