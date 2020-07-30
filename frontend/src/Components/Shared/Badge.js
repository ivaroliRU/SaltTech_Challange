import styled from 'styled-components';

export default styled.span`
    color: #fff;
    background-color: ${props => props.primary?"#007bff;":"grey"}
    display: ${props => props.show?"inline-block;":"none;"}
    padding: .25em .4em;
    font-size: 75%;
    font-weight: 700;
    line-height: 1;
    text-align: center;
    white-space: nowrap;
    vertical-align: baseline;
    border-radius: .25rem;
    transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
`;