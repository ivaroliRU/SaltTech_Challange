import React from 'react';
import SuggestionsBox from './SuggestionsBox';
import Suggestion from './Suggestion';

export default ({ products, handleClick }) => (
    <SuggestionsBox>
        {products.map((p, i) => (
            <Suggestion key={"suggestion-" + i} onClick={() => handleClick(p.name)}>
                {p.name}
            </Suggestion>
        ))}
    </SuggestionsBox>
);