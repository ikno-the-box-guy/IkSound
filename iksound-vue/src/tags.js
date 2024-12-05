export const buildTagTree = (flatTags, type) => {
    const tagMap = new Map();

    flatTags.forEach((tag) => {
        tag.children = [];
        tagMap.set(tag.id, tag);
    });

    const tree = [];

    flatTags.forEach((tag) => {
        const parentId = tag[`father${type}Id`];
        if (parentId && tagMap.has(parentId)) {
            tagMap.get(parentId).children.push(tag);
        } else {
            tree.push(tag); // No parent or parent not found, add to root
        }
    });

    return tree;
}

export const splitIntoColumns = (items, numColumns) => {
    const columns = Array.from({ length: numColumns }, () => []);
    items.forEach((item, index) => {
        columns[index % numColumns].push(item);
    });
    return columns;
}